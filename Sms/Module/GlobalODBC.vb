Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Security.Cryptography


Module GlobalODBC

#Region "Global Declaration"

    Public ServerDetails As String = ""
    Public gsProjectName As String = "SMS Management System"

    Public gnMaxPwdSno As Integer = 6
    Public gnMaxPwdAttempt As Integer = 5
    Public gbLoginStatus As Boolean = False

    Public gnLoginUserId As Integer
    Public gsLoginUserName As String = ""
    Public gsLoginUserCode As String = ""
    Public gsLoginUserRights As String
    Public gnLoginUserGrpId As Integer
    Public gsLoginUserPwd As String = ""

    Public gsSystemIp As String = ""
    Public gOdbcConn As New MySqlConnection

    Public gOdbcDAdp As New MySqlDataAdapter
    Public gOdbcCmd As New MySqlCommand

    Public gFso As New FileIO.FileSystem
    Public gsAsciiPath As String = "c:\temp\"
    Public gsReportPath As String = "c:\execute\"
    Public gnSearchId As Long

    Public Const gnUploadTaken As Integer = 1
    Public Const gnUploadDelete As Integer = 2

    Public Const gnSmsUpload As Integer = 1
    Public Const gnSmsDelivered As Integer = 2
    Public Const gnSmsFailed As Integer = 4

    Public Const gnFileImported As Integer = 1
    Public Const gnFileDeleted As Integer = 2

    Public gsQry As String = ""
    Public gsStatusDesc As String = ""

    'Public gnEvenColor As Long = RGB(220, 200, 100)
    'Public gnOddColor As Long = RGB(175, 210, 175)

    'Public gnEvenColor As Long = RGB(201, 201, 255)
    'Public gnOddColor As Long = RGB(235, 235, 255)
    'Public gnHeaderColor As Long = RGB(40, 89, 148)

    Public gnEvenColor As Long = RGB(235, 235, 255)
    Public gnOddColor As Long = RGB(211, 223, 240)

    Public gnRedHighLightColor As Long = RGB(255, 143, 67)
    Public gnHeaderColor As Long = RGB(26, 59, 105)

    Private KEY_192() As Byte = {42, 16, 93, 156, 78, 4, 218, 32, _
            15, 167, 44, 80, 26, 250, 155, 112, 2, 94, 11, 204, 119, 35, 184, 197}

    Private IV_192() As Byte = {55, 103, 246, 79, 36, 99, 167, 3, _
            42, 5, 62, 83, 184, 7, 209, 13, 145, 23, 200, 58, 173, 10, 121, 222}
#End Region
    'For calling the Main form
    Public Sub Main()
        Dim DbUId As String = ""
        Dim DbPort As String = ""
        Dim DbPwd As String = ""
        Dim DbIP As String = ""
        Dim Db As String = ""
        Dim lsLine As String = ""
        Dim sr As StreamReader

        Dim n As Integer = 0
        Dim TestFlag As Boolean

        gsSystemIp = IPAddresses("")
        TestFlag = False

        If TestFlag = False Then
            Try
                sr = FileIO.FileSystem.OpenTextFileReader(Application.StartupPath & "\appconfig.ini")

                While Not sr.EndOfStream
                    lsLine = sr.ReadLine()
                    lsLine = DecryptTripleDES(lsLine)
                    n += 1

                    Select Case n
                        Case 1
                            DbIP = lsLine
                        Case 2
                            DbPort = lsLine
                        Case 3
                            DbUId = lsLine
                        Case 4
                            DbPwd = lsLine
                        Case 5
                            Db = lsLine
                        Case 6
                            gsReportPath = lsLine
                            If Mid(gsReportPath, gsReportPath.Length, 1) <> "\" Then gsReportPath = gsReportPath & "\"
                    End Select
                End While

                sr.Close()

                If FileIO.FileSystem.DirectoryExists(gsAsciiPath) = False Then
                    MsgBox("Invalid Ascii Path", MsgBoxStyle.Information, gsProjectName)
                    frmServerConfiguration.ShowDialog()
                    Exit Sub
                End If

                'ServerDetails = "Driver={Mysql odbc 3.51 Driver};Server=" & DbIP & ";DataBase=" & Db & ";uid=" & DbUId & ";pwd=" & DbPwd & ";port=" & DbPort
                ServerDetails = "Server=" & DbIP & ";DataBase=" & Db & ";uid=" & DbUId & ";pwd=" & DbPwd & ";port=" & DbPort

                Call ConOpenOdbc(ServerDetails)

                frmLogin.ShowDialog()

                If gbLoginStatus = True Then
                    gbLoginStatus = False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
                frmServerConfiguration.ShowDialog()
            End Try
        Else
            ServerDetails = "Server=localhost;DataBase=citi_sms;uid=root;pwd=Root@123;port=3307"
            Call ConOpenOdbc(ServerDetails)
            gbLoginStatus = True
        End If

        gbLoginStatus = True
    End Sub

    Public Sub ConOpenOdbc(ByVal ServerDetails As String)
        If gOdbcConn.State = ConnectionState.Closed Then
            gOdbcConn.ConnectionString = ServerDetails
            gOdbcConn.Open()
            gOdbcCmd.Connection = gOdbcConn
        End If
        'empid = Security.clsEmpId
    End Sub

    Public Sub ConCloseOdbc(ByVal ServerDetails As String)
        If gOdbcConn.State = ConnectionState.Open Then
            gOdbcConn.Close()
        End If
    End Sub

    Public Function gfInsertQry(ByVal strsql As String, ByVal odbcConn As MySqlConnection) As Integer
        Dim recAffected As Long
        gOdbcCmd = New MySqlCommand(strsql, odbcConn)
        gOdbcCmd.CommandType = CommandType.Text
        'Try
        recAffected = gOdbcCmd.ExecuteNonQuery()
        Return recAffected
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Exit Function
        'End Try
    End Function

    Public Function gfInsertStoredprocedure(ByVal strsql As String, ByVal odbcConn As MySqlConnection) As Integer
        Dim recAffected As Long
        gOdbcCmd = New MySqlCommand(strsql, odbcConn)
        gOdbcCmd.CommandType = CommandType.StoredProcedure
        'Try
        recAffected = gOdbcCmd.ExecuteNonQuery()
        Return recAffected
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Exit Function
        'End Try
    End Function

    Public Function DecryptTripleDES(ByVal value As String) As String
        Try
            If value <> "" Then
                value = value.Replace(" ", "+")
                Dim cryptoProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

                'convert from string to byte array
                Dim buffer As Byte() = Convert.FromBase64String(value)
                Dim ms As MemoryStream = New MemoryStream(buffer)
                Dim cs As CryptoStream = New CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_192, IV_192), CryptoStreamMode.Read)
                Dim sr As StreamReader = New StreamReader(cs)

                Return sr.ReadToEnd()
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
            'Handle Exception - Redirect to Error Page
        End Try
    End Function

    Public Function EncryptTripleDES(ByVal value As String) As String
        Try
            If value <> "" Then
                Dim cryptoProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
                Dim ms As MemoryStream = New MemoryStream()
                Dim cs As CryptoStream = New CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_192, IV_192), CryptoStreamMode.Write)
                Dim sw As StreamWriter = New StreamWriter(cs)

                sw.Write(value)
                sw.Flush()
                cs.FlushFinalBlock()
                ms.Flush()

                'convert back to a string
                Return Convert.ToBase64String(ms.GetBuffer(), 0, ms.Length)
            Else
                Return ""
            End If
        Catch ex As Exception
            'Handle Exception - Redirect to Error Page
            Return ""
        End Try
    End Function

    'its IP address in standard and byte format.
    Public Function IPAddresses(ByVal server As String) As String
        Try
            ' Get server related information.
            Dim heserver As Net.IPHostEntry = Net.Dns.GetHostEntry(server)
            ' Loop on the AddressList
            Dim curAdd As Net.IPAddress
            Dim lsIpAddr As String = ""

            For Each curAdd In heserver.AddressList
                ' Display the server IP address in the standard format. In 
                ' IPv4 the format will be dotted-quad notation, in IPv6 it will be
                ' in in colon-hexadecimal notation.
                lsIpAddr = curAdd.ToString()
            Next curAdd

            Return lsIpAddr
        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, gsProjectName)
            Return ""
        End Try
    End Function 'IPAddresses

    Public Sub frmCtrClear(ByVal frmName As Object)
        Dim ctrl As Control
        For Each ctrl In frmName.Controls
            If ctrl.Tag <> "*" Then
                If TypeOf ctrl Is TextBox Then ctrl.Text = ""
                If TypeOf ctrl Is ComboBox Then
                    ctrl.Text = ""
                End If

                If TypeOf ctrl Is Panel Then frmCtrClear(ctrl)
                If TypeOf ctrl Is GroupBox Then frmCtrClear(ctrl)
            End If
        Next
    End Sub

    ''To Clear control in a form
    Public Sub gpTrimAll(ByVal ctrlBag As Object)
        Dim ctrl As Control

        For Each ctrl In ctrlBag.Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Text = Trim(ctrl.Text)
            ElseIf ctrl.Controls.Count > 0 Then
                gpTrimAll(ctrl)
            End If
        Next
    End Sub
    'To get Dataset
    Public Sub gpDataSet(ByVal cmd As MySqlCommand, ByVal tblName As String, ByVal ds As DataSet)
        Dim objDataAdapter As New MySqlDataAdapter(cmd)
        Try
            objDataAdapter.Fill(ds, tblName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    'To get Dataset
    Public Sub gpDataSet(ByVal SQL As String, ByVal tblName As String, ByVal odbcConn As MySqlConnection, ByVal ds As DataSet)
        Dim objDataAdapter As New MySqlDataAdapter(SQL, odbcConn)
        Try
            objDataAdapter.Fill(ds, tblName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    'To Execute Query and return as datareader
    Public Function gfExecuteQry(ByVal strsql As String, ByVal odbcConn As MySqlConnection) As MySqlDataReader
        Dim objCommand As MySqlCommand
        Dim objDataReader As MySqlDataReader
        objCommand = New MySqlCommand(strsql, odbcConn)
        Try
            objDataReader = objCommand.ExecuteReader()
            objCommand.Dispose()
            Return objDataReader
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    'To get Dataset
    Public Function gfDataSet(ByVal SQL As String, ByVal tblName As String, ByVal odbcConn As MySqlConnection) As DataSet
        Try
            Dim objDataAdapter As New MySqlDataAdapter(SQL, odbcConn)
            Dim objDataSet As New DataSet
            objDataAdapter.Fill(objDataSet, tblName)
            Return objDataSet
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    'Binding combo
    Public Sub gpBindCombo(ByVal SQL As String, ByVal Dispfld As String, _
                               ByVal Valfld As String, ByRef ComboName As ComboBox, _
                                ByVal odbcConn As MySqlConnection)

        Dim objDataAdapter As New MySqlDataAdapter
        Dim objCommand As New MySqlCommand
        Dim objDataTable As New Data.DataTable
        Try
            objCommand.Connection = odbcConn
            objCommand.CommandType = CommandType.Text
            objCommand.CommandText = SQL

            objDataAdapter.Dispose()

            objDataAdapter.SelectCommand = objCommand
            objDataAdapter.Fill(objDataTable)
            ComboName.DataSource = objDataTable
            ComboName.DisplayMember = Dispfld
            ComboName.ValueMember = Valfld
            ComboName.SelectedIndex = -1
            ComboName.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
            objDataTable.Dispose()
            objCommand.Dispose()
            objDataAdapter.Dispose()
        End Try
    End Sub

    'Binding combo
    Public Sub gpBindDataGridViewCombo(dt As DataTable, ByVal Dispfld As String, _
                               ByVal Valfld As String, ByRef ComboName As DataGridViewComboBoxColumn)
        Try
            ComboName.DataSource = dt
            ComboName.DisplayMember = Dispfld
            ComboName.ValueMember = Valfld
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Binding combo
    Public Sub gpBindDataGridViewCombo(ByVal SQL As String, ByVal Dispfld As String, _
                               ByVal Valfld As String, ByRef ComboName As DataGridViewComboBoxColumn, _
                                ByVal odbcConn As MySqlConnection)

        Dim objDataAdapter As New MySqlDataAdapter
        Dim objCommand As New MySqlCommand
        Dim objDataTable As New Data.DataTable
        Try
            objCommand.Connection = odbcConn
            objCommand.CommandType = CommandType.Text
            objCommand.CommandText = SQL
            objDataAdapter.SelectCommand = objCommand
            objDataAdapter.Fill(objDataTable)
            ComboName.DataSource = objDataTable
            ComboName.DisplayMember = Dispfld
            ComboName.ValueMember = Valfld
        Catch ex As Exception
            MsgBox(ex.Message)
            objDataTable.Dispose()
            objCommand.Dispose()
            objDataAdapter.Dispose()
        End Try
    End Sub

   Public Function QuoteFilter(ByVal txt As String) As String
        QuoteFilter = Trim(Replace(Replace(Replace(txt, "'", " "), """", """"""), "\", "\\"))
    End Function

    'Excel To DS :Created Date :23-02-2009 :Created By :Ilaya
    Public Function gpExcelDataset(ByVal Qry As String, ByVal Excelpath As String) As DataTable
        Dim fOleDbConString As String = ""
        Dim lobjDataTable As New DataTable
        Dim lobjDataSet As New DataSet
        Dim lobjDataAdapter As New OleDbDataAdapter
        Dim n As Integer

        n = Excelpath.Split(".").Length

        If Excelpath.Split(".")(n - 1).ToLower = "xlsx" Then
            fOleDbConString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" & Excelpath & ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES';"
        Else
            fOleDbConString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" & Excelpath & ";" + "Extended Properties=Excel 8.0;"
        End If

        lobjDataAdapter = New OleDbDataAdapter(Qry, fOleDbConString)
        lobjDataSet = New DataSet("TBL")
        lobjDataAdapter.Fill(lobjDataSet, "TBL")
        lobjDataTable = lobjDataSet.Tables(0)

        Return lobjDataTable
    End Function

    'To Execute Query and return value as string
    Public Function gfExecuteScalar(ByVal strsql As String, ByVal odbcConn As MySqlConnection) As String
        Dim StrVal As String
        Dim objCommand As MySqlCommand
        objCommand = New MySqlCommand(strsql, odbcConn)

        Try
            If IsDBNull(objCommand.ExecuteScalar()) Or IsNothing(objCommand.ExecuteScalar()) Then
                StrVal = ""
            Else
                StrVal = objCommand.ExecuteScalar()
            End If

            objCommand.Dispose()
            Return StrVal

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    'To Bind values to Datagrid
    Public Sub gpPopGridView(ByVal GridName As DataGridView, ByVal Qry As String, ByVal odbcConn As MySqlConnection)
        Dim lda As New MySqlDataAdapter(Qry, odbcConn)
        Dim lds As New DataSet
        Dim ldt As DataTable
        Try
            lda.Fill(lds, "tbl")
            ldt = lds.Tables("tbl")
            GridName.DataSource = ldt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function AmtInWords(ByRef amt As Double, ByRef Rupees As String, ByRef Paise As String, ByRef Only As String) As String
        Dim m As Long
        Dim n As Short
        Dim b As String = ""
        Dim a As String = ""
        Dim C As String = ""

        m = Int(amt)
        n = Math.Round(((amt - m) * 100), 0)

        If m <> 0 Then
            a = English(m)
            'If n <> 0 Then
            b = " and "
        End If
        'If n <> 0 Then
        If n > 0 Then
            C = Paise & " " & English(n)
        Else
            b = ""
        End If

        AmtInWords = Rupees & " " & a & b & C & " " & Only
    End Function
    Function English(ByVal n As Long) As String
        Const Thousand As Long = 1000
        Const Lakh As Long = Thousand * 100
        Const Crore As Long = Thousand * 10000
        'Const Trillion = Thousand * Crore

        Dim Buf As String : Buf = ""

        If (n = 0) Then English = "zero" : Exit Function

        If (n < 0) Then Buf = "negative " : n = -n

        If (n >= Crore) Then
            Buf = Buf & EnglishDigitGroup(n \ Crore) & " crore"
            n = n Mod Crore
            If (n) Then Buf = Buf & " "
        End If

        If (n >= Lakh) Then
            Buf = Buf & EnglishDigitGroup(n \ Lakh) & " lakh"
            n = n Mod Lakh
            If (n) Then Buf = Buf & " "
        End If

        If (n >= Thousand) Then
            Buf = Buf & EnglishDigitGroup(n \ Thousand) & " thousand"
            n = n Mod Thousand
            If (n) Then Buf = Buf & " "
        End If

        If (n > 0) Then
            Buf = Buf & EnglishDigitGroup(n)
        End If

        English = Buf
    End Function
    ' Support function to be used only by English()
    Function EnglishDigitGroup(ByVal n As Short) As String
        Const Hundred As String = " hundred"
        Const One As String = "one"
        Const Two As String = "two"
        Const Three As String = "three"
        Const Four As String = "four"
        Const Five As String = "five"
        Const Six As String = "six"
        Const Seven As String = "seven"
        Const Eight As String = "eight"
        Const Nine As String = "nine"
        Dim Buf As String : Buf = ""
        Dim Flag As Short : Flag = False

        'Do hundreds
        Select Case (n \ 100)
            Case 0 : Buf = "" : Flag = False
            Case 1 : Buf = One & Hundred : Flag = True
            Case 2 : Buf = Two & Hundred : Flag = True
            Case 3 : Buf = Three & Hundred : Flag = True
            Case 4 : Buf = Four & Hundred : Flag = True
            Case 5 : Buf = Five & Hundred : Flag = True
            Case 6 : Buf = Six & Hundred : Flag = True
            Case 7 : Buf = Seven & Hundred : Flag = True
            Case 8 : Buf = Eight & Hundred : Flag = True
            Case 9 : Buf = Nine & Hundred : Flag = True
        End Select

        If (Flag) Then n = n Mod 100
        If (n) Then
            If (Flag) Then Buf = Buf & " "
        Else
            EnglishDigitGroup = Buf
            Exit Function
        End If

        'Do tens (except teens)
        Select Case (n \ 10)
            Case 0, 1 : Flag = False
            Case 2 : Buf = Buf & "twenty" : Flag = True
            Case 3 : Buf = Buf & "thirty" : Flag = True
            Case 4 : Buf = Buf & "forty" : Flag = True
            Case 5 : Buf = Buf & "fifty" : Flag = True
            Case 6 : Buf = Buf & "sixty" : Flag = True
            Case 7 : Buf = Buf & "seventy" : Flag = True
            Case 8 : Buf = Buf & "eighty" : Flag = True
            Case 9 : Buf = Buf & "ninety" : Flag = True
        End Select

        If (Flag) Then n = n Mod 10
        If (n) Then
            If (Flag) Then Buf = Buf & "-"
        Else
            EnglishDigitGroup = Buf
            Exit Function
        End If

        'Do ones and teens
        Select Case (n)
            Case 0 ' do nothing
            Case 1 : Buf = Buf & One
            Case 2 : Buf = Buf & Two
            Case 3 : Buf = Buf & Three
            Case 4 : Buf = Buf & Four
            Case 5 : Buf = Buf & Five
            Case 6 : Buf = Buf & Six
            Case 7 : Buf = Buf & Seven
            Case 8 : Buf = Buf & Eight
            Case 9 : Buf = Buf & Nine
            Case 10 : Buf = Buf & "ten"
            Case 11 : Buf = Buf & "eleven"
            Case 12 : Buf = Buf & "twelve"
            Case 13 : Buf = Buf & "thirteen"
            Case 14 : Buf = Buf & "fourteen"
            Case 15 : Buf = Buf & "fifteen"
            Case 16 : Buf = Buf & "sixteen"
            Case 17 : Buf = Buf & "seventeen"
            Case 18 : Buf = Buf & "eighteen"
            Case 19 : Buf = Buf & "nineteen"
        End Select

        EnglishDigitGroup = Buf
    End Function

    'textwith
    Function ToRight(text As String, length As Integer)
        If text.Length > length Then
            Return text.Substring(0, length)
        Else
            Return text.PadRight(length)
        End If
    End Function

    Function ToLeft(text As String, length As Integer)
        If text.Length > length Then
            Return text.Substring(0, length)
        Else
            Return text.PadLeft(length)
        End If
    End Function

    Public Sub ShowQuery(Qry As String, con As MySqlConnection)
        Dim frm As New frmQuickView(con, Qry)
        frm.ShowDialog()
    End Sub
    'AutoFillCombo :Created Date :24-02-2009 :Created By :Ilaya
    Public Sub gpAutoFillCombo(ByVal cboBox As ComboBox)

        Dim lnLenght As Long

        With cboBox

            lnLenght = .Text.Length

            .SelectedIndex = .FindString(.Text)

            .SelectionStart = lnLenght

            .SelectionLength = Math.Abs(.Text.Length - lnLenght)

        End With

    End Sub

    'AutoFillCombo :Created Date :24-02-2009 Created By :Ilaya
    Public Sub gpAutoFindCombo(ByVal cboBox As ComboBox)
        cboBox.SelectedIndex = cboBox.FindString(cboBox.Text)
    End Sub

    Public Sub RowColor(ByVal ctrl As AxMSFlexGridLib.AxMSFlexGrid, ByVal StartRow As Integer, ByVal EndRow As Integer, ByVal BkColor As Long)
        Dim i As Integer, j As Integer

        With ctrl
            For i = StartRow To EndRow
                .Row = i

                For j = .FixedCols To .Cols - 1
                    .Col = j
                    .CellBackColor = ColorTranslator.FromWin32(BkColor)
                Next j
            Next i
        End With
    End Sub

    Public Sub RowColor(ByVal ctrl As AxMSFlexGridLib.AxMSFlexGrid, ByVal StartRow As Integer, ByVal EndRow As Integer, ByVal BkColor As Long, ForeColor As Long)
        Dim i As Integer, j As Integer

        With ctrl
            For i = StartRow To EndRow
                .Row = i

                For j = .FixedCols To .Cols - 1
                    .Col = j
                    .CellBackColor = ColorTranslator.FromWin32(BkColor)
                    .CellForeColor = ColorTranslator.FromWin32(ForeColor)
                Next j
            Next i
        End With
    End Sub

    Public Sub RowForeColor(ByVal ctrl As AxMSFlexGridLib.AxMSFlexGrid, ByVal StartRow As Integer, ByVal EndRow As Integer, ByVal ForeColor As Long)
        Dim i As Integer, j As Integer

        With ctrl
            For i = StartRow To EndRow
                .Row = i

                For j = .FixedCols To .Cols - 1
                    .Col = j
                    .CellForeColor = ColorTranslator.FromWin32(ForeColor)
                Next j
            Next i
        End With
    End Sub

    Public Sub RowColor(ByVal ctrl As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid, ByVal StartRow As Integer, ByVal EndRow As Integer, ByVal BkColor As Long)
        Dim i As Integer, j As Integer

        Try
            With ctrl
                For i = StartRow To EndRow
                    .Row = i

                    For j = .FixedCols To .get_Cols - 1
                        .Col = j
                        .CellBackColor = ColorTranslator.FromWin32(BkColor)
                    Next j
                Next i
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Public Function PrfAccBal(ByVal AccNo As String, ByVal TranDate As Date) As Double
        Dim lsTranDate As String
        Dim lnBalAmt As Double = 0
        Dim lsSql As String

        lsSql = ""
        lsSql &= " select max(tran_date) from div_trn_taccbal "
        lsSql &= " where tran_date <= '" & Format(TranDate, "yyyy-MM-dd") & "' "
        lsSql &= " and acc_no = '" & AccNo & "' "
        lsSql &= " and delete_flag = 'N' "

        lsTranDate = gfExecuteScalar(lsSql, gOdbcConn)

        If lsTranDate <> "" Then
            lsTranDate = Format(CDate(lsTranDate), "yyyy-MM-dd")

            lsSql = ""
            lsSql &= " select acc_balance from div_trn_taccbal "
            lsSql &= " where tran_date = '" & lsTranDate & "' "
            lsSql &= " and acc_no = '" & AccNo & "' "
            lsSql &= " and delete_flag = 'N' "

            lnBalAmt = Val(gfExecuteScalar(lsSql, gOdbcConn))
        End If

        Return lnBalAmt
    End Function

    Public Function PrfExcpBal(ByVal AccNo As String, ByVal TranDate As Date) As Double
        Dim lnBalAmt As Double = 0
        Dim lsSql As String

        lsSql = ""
        lsSql &= " select sum(excp_amount*mult) from div_trn_ttran "
        lsSql &= " where tran_date <= '" & Format(TranDate, "yyyy-MM-dd") & "' "
        lsSql &= " and acc_no = '" & AccNo & "' "
        lsSql &= " and excp_amount > 0 "
        lsSql &= " and delete_flag = 'N' "

        lnBalAmt = Val(gfExecuteScalar(lsSql, gOdbcConn))

        Return Math.Round(lnBalAmt, 2)
    End Function

    Public Function PrfTranBal(ByVal AccNo As String, TranDate As Date) As Double
        Dim lnExcpAmt As Double = 0
        Dim lsSql As String

        lsSql = ""
        lsSql &= " select sum(tran_amount*mult) from div_trn_ttran "
        lsSql &= " where tran_date <= '" & Format(TranDate, "yyyy-MM-dd") & "' "
        lsSql &= " and acc_no = '" & AccNo & "' "
        lsSql &= " and delete_flag = 'N' "

        lnExcpAmt = Val(gfExecuteScalar(lsSql, gOdbcConn))

        Return lnExcpAmt
    End Function

    'To Execute Query and return value as boolean
    Public Function gfExecuteQryBln(ByVal strsql As String, ByVal odbcConn As MySqlConnection) As Boolean
        Dim objDataReader As MySqlDataReader
        gOdbcCmd = New MySqlCommand(strsql, odbcConn)

        Try
            objDataReader = gOdbcCmd.ExecuteReader()
            If objDataReader.HasRows Then
                objDataReader.Close()
                Return True
            Else
                objDataReader.Close()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub gpUpdateFileRemark(FileId As Long, Remark As String)
        Using cmd As New MySqlCommand("pr_div_set_fileremark", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_file_gid", FileId)
            cmd.Parameters.AddWithValue("?in_file_remark", Mid(QuoteFilter(Remark), 1, 255))

            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Function gfGetFolioNo(FolioNo As String) As String
        Dim lsFolioNo As String = FolioNo
        lsFolioNo = lsFolioNo.ToUpper
        lsFolioNo = lsFolioNo.Replace(" ", "")
        lsFolioNo = lsFolioNo.Replace("FOLIONO.:", "").Trim
        lsFolioNo = lsFolioNo.Replace("FOLIONO.", "").Trim
        lsFolioNo = lsFolioNo.Replace("FOLIONO:", "").Trim
        lsFolioNo = lsFolioNo.Replace("FOLIO:", "").Trim
        lsFolioNo = lsFolioNo.Replace("FOLIO", "").Trim
        lsFolioNo = lsFolioNo.Replace("FOLIO/DP-CLIENTID", "").Trim

        If lsFolioNo.Split("-").Length > 0 Then
            lsFolioNo = lsFolioNo.Split("-")(0)
        End If

        Return lsFolioNo
    End Function

    Public Function gfChkFolioNo(FolioNo As String) As Boolean
        If FolioNo.ToUpper.Contains("FOLIO") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function gfChkWarrantNo(WarrantNo As String) As Boolean
        Dim lsWarrantNo As String = WarrantNo
        lsWarrantNo = lsWarrantNo.Trim.ToUpper
        lsWarrantNo = lsWarrantNo.Replace(" ", "")

        If lsWarrantNo.Contains("WARRANTNO.:") Then Return True
        If lsWarrantNo.Contains("WARRANTNO.") Then Return True
        If lsWarrantNo.Contains("WARRANTNO:") Then Return True
        If lsWarrantNo.Contains("WARRANT") Then Return True
        If lsWarrantNo.Contains("WNO:") Then Return True
        If lsWarrantNo.Contains("WNO") Then Return True

        Return False
    End Function

    Public Function gfGetWarrantNo(WarrantNo As String) As String
        Dim lsWarrantNo As String = WarrantNo
        lsWarrantNo = lsWarrantNo.Replace(" ", "")

        lsWarrantNo = lsWarrantNo.Replace("WARRANTNO.:", "").Trim
        lsWarrantNo = lsWarrantNo.Replace("WARRANTNO.", "").Trim
        lsWarrantNo = lsWarrantNo.Replace("WARRANTNO:", "").Trim
        lsWarrantNo = lsWarrantNo.Replace("WNO:", "").Trim
        lsWarrantNo = lsWarrantNo.Replace("FOLIO/DP-CLIENT ID", "").Trim

        Return lsWarrantNo
    End Function

    Private Function priority(ByVal token As String) As Integer
        Select Case token
            Case "^"
                priority = 3
            Case "*", "/"
                priority = 2
            Case "+", "-"
                priority = 1
            Case "("
                priority = 4
            Case Else
                priority = 0
        End Select
    End Function

    ' Function to convert Infix to Postfix expression
    Private Function PostFix(ByVal infix As String) As String
        On Error Resume Next

        Dim i As Integer, m As String, s As String, c As String = "", j As Integer
        Dim num As String = "", a As String = "", n As Integer

        n = 0
        s = ""

        For i = 1 To Len(infix)
            m = Mid(infix, i, 1)

            Select Case m
                Case "(", ")", "^", "*", "/", "+", "-"
                    If num <> "" Then
                        num = num + """"
                        s = s + num
                        num = ""
                    End If

                    If m <> ")" Then
                        For j = n To 1 Step -1

                            'c = pop

                            c = Mid(a, n, 1)
                            n = n - 1
                            a = Mid(a, 1, n)

                            If priority(c) >= priority(m) And priority(c) <> 4 Then
                                s = s + c + """"
                            Else
                                'push (c)

                                n = n + 1
                                a = a + c

                                Exit For
                            End If
                        Next j

                        'push (m)
                        n = n + 1
                        a = a + m
                    Else
                        For j = n To 1 Step -1
                            'c = pop

                            c = Mid(a, n, 1)
                            n = n - 1
                            a = Mid(a, 1, n)

                            If c <> "(" Then
                                s = s + c + """"
                            Else
                                Exit For
                            End If
                        Next j
                    End If
                Case Else
                    num = num + m
                    's = s + m
            End Select
        Next i

        If num <> "" Then
            s = s + num + """"
        End If

        For i = n To 1 Step -1
            'c = pop

            c = Mid(a, n, 1)
            n = n - 1
            a = Mid(a, 1, n)

            s = s + c + """"
        Next i

        PostFix = s
    End Function

    ' Function to evaluate the value of infix string
    Public Function evaluate(ByVal infix As String) As Double
        On Error Resume Next

        Dim i As Integer, m As String, t As String = "", post_fix As String
        Dim stack() As Double, n As Integer
        Dim X As Double, Y As Double

        ReDim stack(infix.Length * 2)

        post_fix = PostFix(CompressInfix(infix))
        n = -1

        For i = 1 To Len(post_fix)
            m = Mid(post_fix, i, 1)

            If m = """" Then
                Select Case t
                    Case "+", "-", "*", "/", "^"
                        X = stack(n)

                        If n > 0 Then
                            Y = stack(n - 1)
                        Else
                            Y = 0
                        End If

                        If n <= 0 Then
                            n = 0
                        Else
                            n = n - 1
                        End If

                        Select Case t
                            Case "*"
                                stack(n) = X * Y
                            Case "/"
                                stack(n) = Y / X
                            Case "+"
                                stack(n) = X + Y
                            Case "-"
                                stack(n) = Y - X
                            Case "^"
                                stack(n) = Y ^ X
                        End Select
                    Case Else
                        n = n + 1
                        stack(n) = Val(t)
                End Select
                t = ""
            Else
                t = t + m
            End If
        Next i

        evaluate = stack(0)
    End Function

    ' Function to compress Infix expression
    Private Function CompressInfix(ByVal Infix As String) As String
        On Error Resume Next

        Dim i As Integer, m As String, t As String = "", post_fix As String
        Dim stack() As Double, n As Integer, p As Integer = 0, q As Integer = 0
        Dim CompInfix() As String

        ReDim CompInfix(Infix.Length)

        n = -1

        For i = 1 To Infix.Length
            n += 1

            m = Mid(Infix, i, 1)
            CompInfix(n) = m

            If m = ")" Then
                m = ""
                t = ""
                p = 1
                q = 0

                CompInfix(n) = ""
                n = n - 1

                While Not (m = "(" And p = q)
                    m = CompInfix(n)
                    If m = ")" Then p += 1

                    CompInfix(n) = ""
                    t = m + t

                    n = n - 1
                    m = CompInfix(n)

                    If m = "(" Then q += 1
                End While

                m = CStr(evaluate(t))

                If m < 0 Then
                    n = n + 1
                    CompInfix(n) = "0"
                End If

                n = n + 1
                CompInfix(n) = m

                n = n + 1
                CompInfix(n) = ")"
            End If
        Next i

        m = ""

        For i = 0 To n
            m = m + CompInfix(i)
        Next i

        Return m
    End Function
End Module