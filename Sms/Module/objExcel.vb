Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports System

Module objExcel
    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, _
            ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, _
            ByVal nShowCmd As Integer) As Integer
    Const SW_SHOWNORMAL As Short = 1

    Public Sub DgridToExcel(ByVal Dgrid As DataGrid, ByVal ExcelFileName As String, ByVal SheetName As String, Optional ByVal StoreasNum As String = "")

        Dim Col As Integer, Row As Integer, TotCol As Integer, TotSheets As Integer
        Dim NumericCols() As String
        Dim objApplication As New Excel.Application
        Dim objBooks As Excel.Workbooks
        Dim objWorkBook As Excel.Workbook
        Dim objWorkSheet As Excel.Worksheet

        Try
            NumericCols = Split(StoreasNum, "|")

            Row = 1

            If File.Exists(ExcelFileName) = False Then
                objBooks = objApplication.Workbooks
                objWorkBook = objBooks.Add()
                objWorkSheet = objApplication.Worksheets.Add()
                objWorkSheet.Name = SheetName
                objWorkBook.SaveAs(ExcelFileName, 1)
            Else
                objBooks = objApplication.Workbooks
                objWorkBook = objBooks.Open(ExcelFileName, False, False)
                TotSheets = objWorkBook.Sheets.Count
                While TotSheets > 0
                    objWorkSheet = objWorkBook.Sheets(TotSheets)
                    If objWorkSheet.Name = SheetName Then
                        SheetName = SheetName & "+"
                        TotSheets = objWorkBook.Sheets.Count
                    Else
                        TotSheets = TotSheets - 1
                    End If
                End While
                objWorkSheet = objApplication.Worksheets.Add()
                objWorkSheet.Name = SheetName
            End If

            objApplication.Visible = True

            'objDataTable = Dgrid.DataSource
            TotCol = Dgrid.VisibleColumnCount

            For Col = 1 To TotCol
                objWorkSheet.Cells(Row, Col) = Dgrid.Item(0, Col - 1).ToString
                objWorkSheet.Cells(Row, Col).interior.colorindex = 10
                objWorkSheet.Cells(Row, Col).font.colorindex = 6
                objWorkSheet.Cells(Row, Col).Font.Bold = True
                objWorkSheet.Cells(Row, Col).Borders.ColorIndex = 56
            Next


            For Col = 1 To TotCol
                For Row = 1 To Dgrid.VisibleRowCount
                    If IsNumericFldCol(Col, NumericCols) = False Then
                        objWorkSheet.Cells(Row + 2, Col) = "'" & Dgrid.Item(Col - 1, Row)
                    Else
                        objWorkSheet.Cells(Row + 2, Col) = Dgrid.Item(Col - 1, Row).Value.ToString
                    End If
                    objWorkSheet.Cells(Row + 2, Col).Borders.ColorIndex = 56
                Next
            Next

            objWorkSheet.Columns.AutoFit()
            For Col = 1 To TotCol
                If objWorkSheet.Columns(Col).ColumnWidth > 40 Then
                    objWorkSheet.Columns(Col).ColumnWidth = 40
                    objWorkSheet.Columns(Col).WrapText = True
                End If
            Next


            objWorkBook.Save()

            'NAR(objWorkSheet)
            objWorkBook.Close(False)
            'NAR(objWorkBook)
            objBooks.Close()
            'NAR(objBooks)
            objApplication.Quit()
            'NAR(objApplication)
            'GC.Collect()
            'GC.WaitForPendingFinalizers()
            MsgBox("Created Successfully ", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Public Sub DgridViewToExcel(ByVal Dgrid As DataGridView, ByVal ExcelFileName As String, ByVal SheetName As String, Optional ByVal StoreasNum As String = "")
        Dim Col As Integer, Row As Integer, TotCol As Integer, TotSheets As Integer
        Dim NumericCols() As String
        'Dim objDataTable As New DataGridView
        Dim objApplication As New Excel.Application
        Dim objBooks As Excel.Workbooks
        Dim objWorkBook As Excel.Workbook
        Dim objWorkSheet As Excel.Worksheet

        Try
            NumericCols = Split(StoreasNum, "|")

            Row = 1

            If File.Exists(ExcelFileName) = False Then
                objBooks = objApplication.Workbooks
                objWorkBook = objBooks.Add()
                objWorkSheet = objApplication.Worksheets.Add()
                objWorkSheet.Name = SheetName
                objWorkBook.SaveAs(ExcelFileName, 1)
            Else
                objBooks = objApplication.Workbooks
                objWorkBook = objBooks.Open(ExcelFileName, False, False)
                TotSheets = objWorkBook.Sheets.Count
                While TotSheets > 0
                    objWorkSheet = objWorkBook.Sheets(TotSheets)
                    If objWorkSheet.Name = SheetName Then
                        SheetName = SheetName & "+"
                        TotSheets = objWorkBook.Sheets.Count
                    Else
                        TotSheets = TotSheets - 1
                    End If
                End While
                objWorkSheet = objApplication.Worksheets.Add()
                objWorkSheet.Name = SheetName
            End If

            objApplication.Visible = True

            'objDataTable = Dgrid.DataSource
            TotCol = Dgrid.ColumnCount

            For Col = 1 To TotCol
                objWorkSheet.Cells(Row, Col) = Dgrid.Columns(Col - 1).Name.ToString
                objWorkSheet.Cells(Row, Col).interior.colorindex = 10
                objWorkSheet.Cells(Row, Col).font.colorindex = 6
                objWorkSheet.Cells(Row, Col).Font.Bold = True
                objWorkSheet.Cells(Row, Col).Borders.ColorIndex = 56
            Next

            For Row = 0 To Dgrid.RowCount - 1
                For Col = 1 To TotCol
                    If IsNumericFldCol(Col, NumericCols) = False Then
                        objWorkSheet.Cells(Row + 2, Col) = "'" & Dgrid.Item(Col - 1, Row).Value.ToString
                    Else
                        objWorkSheet.Cells(Row + 2, Col) = Dgrid.Item(Col - 1, Row).Value.ToString
                    End If
                    objWorkSheet.Cells(Row + 2, Col).Borders.ColorIndex = 56
                Next
            Next

            objWorkSheet.Columns.AutoFit()
            For Col = 1 To TotCol
                If objWorkSheet.Columns(Col).ColumnWidth > 40 Then
                    objWorkSheet.Columns(Col).ColumnWidth = 40
                    objWorkSheet.Columns(Col).WrapText = True
                End If
            Next


            objWorkBook.Save()

            'NAR(objWorkSheet)
            objWorkBook.Close(False)
            'NAR(objWorkBook)
            objBooks.Close()
            'NAR(objBooks)
            objApplication.Quit()
            'NAR(objApplication)
            'GC.Collect()
            'GC.WaitForPendingFinalizers()
            MsgBox("Created Successfully ", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Public Sub SqlToExcel(ByVal SqlStr As String, ByVal ExcelFileName As String, ByVal SheetName As String, Optional ByVal DelFlag As Boolean = False, Optional ByVal StoreasNum As String = "")
        Dim Col As Integer, Row As Integer, TotSheets As Integer
        Dim NumericCols() As String

        Dim objDataReader As MySql.Data.MySqlClient.MySqlDataReader
        Dim objApplication As New Excel.Application
        Dim objBooks As Excel.Workbooks
        Dim objWorkBook As Excel.Workbook
        Dim objWorkSheet As Excel.Worksheet

        Row = 0
        NumericCols = Split(StoreasNum, "|")

        If DelFlag = True And File.Exists(ExcelFileName) = True Then File.Delete(ExcelFileName)

        If File.Exists(ExcelFileName) = False Then
            objBooks = objApplication.Workbooks
            objWorkBook = objBooks.Add()
            objWorkSheet = objApplication.Worksheets.Add()
            objWorkSheet.Name = SheetName
            objWorkBook.SaveAs(ExcelFileName, 1)
        Else
            objBooks = objApplication.Workbooks
            objWorkBook = objBooks.Open(ExcelFileName, False, False)
            TotSheets = objWorkBook.Sheets.Count
            While TotSheets > 0
                objWorkSheet = objWorkBook.Sheets(TotSheets)
                If objWorkSheet.Name = SheetName Then
                    SheetName = SheetName & "+"
                    TotSheets = objWorkBook.Sheets.Count
                Else
                    TotSheets = TotSheets - 1
                End If
            End While
            objWorkSheet = objApplication.Worksheets.Add()
            objWorkSheet.Name = SheetName
        End If

        objApplication.Visible = True

        objDataReader = gfExecuteQry(SqlStr, gOdbcConn)
        If objDataReader.HasRows = True Then
            Row = Row + 1
            For Col = 0 To objDataReader.FieldCount - 1
                objWorkSheet.Cells(Row, Col + 1) = "'" & objDataReader.GetName(Col).ToString
                objWorkSheet.Cells(Row, Col + 1).interior.colorindex = 10
                objWorkSheet.Cells(Row, Col + 1).font.colorindex = 6
                objWorkSheet.Cells(Row, Col + 1).font.bold = True
                objWorkSheet.Cells(Row, Col + 1).Borders.ColorIndex = 56
            Next
            While objDataReader.Read()
                Row = Row + 1
                With objWorkSheet
                    For Col = 0 To objDataReader.FieldCount - 1
                        If IsNumericFldCol(Col + 1, NumericCols) = False Then
                            .Cells(Row, Col + 1) = "'" & objDataReader.Item(Col).ToString
                        Else
                            .Cells(Row, Col + 1) = objDataReader.Item(Col).ToString
                        End If
                    Next
                End With
            End While
        End If

        objWorkSheet.Columns.AutoFit()
        For Col = 0 To objDataReader.FieldCount - 1
            If objWorkSheet.Columns(Col + 1).ColumnWidth > 40 Then
                objWorkSheet.Columns(Col + 1).ColumnWidth = 40
                objWorkSheet.Columns(Col + 1).WrapText = True
            End If
        Next

        objDataReader.Close()
        objWorkBook.Save()

        'NAR(objWorkSheet)
        objWorkBook.Close(False)
        'NAR(objWorkBook)
        objBooks.Close()
        'NAR(objBooks)
        objApplication.Quit()
        'NAR(objApplication)
        'GC.Collect()
        'GC.WaitForPendingFinalizers()
    End Sub

    Public Sub SqlToXml(ByVal SqlStr As String, ByVal ExcelFileName As String, ByVal SheetName As String, _
                              Optional ByVal ShowFlag As Boolean = True, _
                              Optional ByVal DelFlag As Boolean = True)
        Dim ds As New DataSet
        Dim objStreamReader As StreamReader
        Dim lsTextContent As String

        Dim n As Integer = 0, i As Integer = 0, j As Integer = 0, c As Integer = 0
        Dim lsTxt As String = ""

        Try
            If File.Exists(ExcelFileName) = True And DelFlag = True Then File.Delete(ExcelFileName)

            If File.Exists(ExcelFileName) = False Then
                FileOpen(1, ExcelFileName, OpenMode.Append)

                PrintLine(1, "<?xml version=""1.0"" encoding=""utf-8""?>")
                PrintLine(1, "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

                PrintLine(1, "<Styles>")
                PrintLine(1, "<Style ss:ID=""s1"">")
                PrintLine(1, "<Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "<Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s2"">")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s3"">")
                'PrintLine(1, "<Alignment ss:Horizontal=""left"" ss:Vertical=""centre""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "</Style>")
                PrintLine(1, "</Styles>")
            Else
                objStreamReader = File.OpenText(ExcelFileName)
                lsTextContent = objStreamReader.ReadToEnd()
                lsTextContent = lsTextContent.ToString.Replace("</Workbook>", "")
                objStreamReader.Close()
                FileOpen(1, ExcelFileName, OpenMode.Output)
                PrintLine(1, lsTextContent.ToString)
            End If

            PrintLine(1, "<Worksheet ss:Name=""" & SheetName & """>")

            gpDataSet(SqlStr, "data", gOdbcConn, ds)

            With ds.Tables("data")
                PrintLine(1, "<Table ss:ExpandedColumnCount=" & Chr(34) & .Columns.Count + 2 & Chr(34) & " " & _
                             "ss:ExpandedRowCount=" & Chr(34) & .Rows.Count + n + 2 & Chr(34) & ">")

                PrintLine(1, "<Row>")
                PrintLine(1, "<Cell ss:StyleID=""s1""><Data ss:Type=""String"" x:Ticked=""1"">SNo</Data></Cell>")

                For i = 0 To .Columns.Count - 1
                    PrintLine(1, "<Cell ss:StyleID=""s1""><Data ss:Type=""String"" x:Ticked=""1"">" & .Columns(i).ColumnName & "</Data></Cell>")
                Next i

                PrintLine(1, "</Row>")

                For i = 0 To .Rows.Count - 1
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"" x:Ticked=""1"">" & i + 1 & "</Data></Cell>")

                    For j = 0 To .Columns.Count - 1
                        lsTxt = .Rows(i).Item(j).ToString
                        lsTxt = lsTxt.Replace("<", "< ")
                        lsTxt = lsTxt.Replace(">", " >")

                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    Next j

                    PrintLine(1, "</Row>")
                Next i
            End With

            PrintLine(1, "</Table>")
            PrintLine(1, "</Worksheet>")
            PrintLine(1, "</Workbook>")

            FileClose(1)
            FileClose(2)

            If ShowFlag = True Then ShellExecute(frmMain.Handle.ToInt32, "open", ExcelFileName, "", "0", SW_SHOWNORMAL)
        Catch ex As Exception
            FileClose(1)
            ' objMail.GF_Mail(gsMailFrom, gsMailTo, gsMailSub, ex.Message, gsFormName, "SqlToXml")
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NAR(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            o = Nothing
        End Try
    End Sub

    Public Sub FlexToExcel(ByVal Fgrid As AxMSFlexGridLib.AxMSFlexGrid, ByVal ExcelFileName As String, ByVal SheetName As String, Optional ByVal StoreasNum As String = "")
        Dim Col As Integer, Row As Integer, TotSheets As Integer
        Dim NumericCols() As String
        Dim objApplication As New Excel.Application
        Dim objBooks As Excel.Workbooks
        Dim objWorkBook As Excel.Workbook
        Dim objWorkSheet As Excel.Worksheet

        Row = 0
        NumericCols = Split(StoreasNum, "|")

        If File.Exists(ExcelFileName) = False Then
            objBooks = objApplication.Workbooks
            objWorkBook = objBooks.Add()
            objWorkSheet = objApplication.Worksheets.Add()
            objWorkSheet.Name = SheetName
            objWorkBook.SaveAs(ExcelFileName, 1)
        Else
            objBooks = objApplication.Workbooks
            objWorkBook = objBooks.Open(ExcelFileName, False, False)
            TotSheets = objWorkBook.Sheets.Count
            While TotSheets > 0
                objWorkSheet = objWorkBook.Sheets(TotSheets)
                If objWorkSheet.Name = SheetName Then
                    SheetName = SheetName & "+"
                    TotSheets = objWorkBook.Sheets.Count
                Else
                    TotSheets = TotSheets - 1
                End If
            End While
            objWorkSheet = objApplication.Worksheets.Add()
            objWorkSheet.Name = SheetName
        End If

        objApplication.Visible = True
        With Fgrid
            For Row = 0 To .Rows - 1
                .Row = Row
                For Col = 0 To .Cols - 1
                    .Col = Col
                    If .CellBackColor.ToString <> Color.Black.ToString Then
                        'objWorkSheet.Cells(Row + 1, Col + 1).Interior.Color = ColorTranslator.ToWin32(.CellBackColor)
                    End If
                    If Row = 0 Then
                        objWorkSheet.Cells(Row + 1, Col + 1).Font.Bold = True
                    End If
                    If IsNumericFldCol(Col + 1, NumericCols) = False Then
                        objWorkSheet.Cells(Row + 1, Col + 1) = "'" & .get_TextMatrix(Row, Col)
                    Else
                        objWorkSheet.Cells(Row + 1, Col + 1) = .get_TextMatrix(Row, Col)
                    End If
                    objWorkSheet.Cells(Row + 1, Col + 1).Borders.ColorIndex = 56
                Next Col
            Next Row
            objWorkSheet.Columns.AutoFit()
            For Col = 0 To .Cols - 1
                If objWorkSheet.Columns(Col + 1).ColumnWidth > 40 Then
                    objWorkSheet.Columns(Col + 1).ColumnWidth = 40
                    objWorkSheet.Columns(Col + 1).WrapText = True
                End If
            Next
        End With

        objWorkBook.Save()

        'NAR(objWorkSheet)
        objWorkBook.Close(False)
        'NAR(objWorkBook)
        objBooks.Close()
        'NAR(objBooks)
        objApplication.Quit()
        'NAR(objApplication)
        'GC.Collect()
        'GC.WaitForPendingFinalizers()
        MsgBox("Created Successfully ", MsgBoxStyle.Information)
    End Sub

    Public Sub PrintFGridXML(ByVal FlexGrid As AxMSFlexGridLib.AxMSFlexGrid, ByVal FileName As String, _
                                 Optional ByVal SheetName As String = "Report", _
                                 Optional ByVal Header1 As String = "", _
                                 Optional ByVal Header2 As String = "", _
                                 Optional ByVal Header3 As String = "", _
                                 Optional ByVal Header4 As String = "", _
                                 Optional ByVal ShowFlag As Boolean = True, _
                                 Optional ByVal DelFlag As Boolean = True, _
                                 Optional ByVal PlainFlag As Boolean = False)

        Dim objDataTable As New Data.DataTable
        Dim Col As Integer, Row As Integer
        Dim objStreamReader As StreamReader
        Dim lsTextContent As String

        Dim n As Integer = 0
        Dim lsTxt As String = ""
        Dim lsStyle As String = ""

        Try
            If File.Exists(FileName) = True And DelFlag = True Then File.Delete(FileName)

            If File.Exists(FileName) = False Then
                FileOpen(1, FileName, OpenMode.Append)

                PrintLine(1, "<?xml version=""1.0"" encoding=""utf-8""?>")
                PrintLine(1, "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

                PrintLine(1, "<Styles>")
                PrintLine(1, "<Style ss:ID=""s1"">")
                PrintLine(1, "<Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "<Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s2"">")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s3"">")
                'PrintLine(1, "<Alignment ss:Horizontal=""left"" ss:Vertical=""centre""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s4"">")
                'PrintLine(1, "<Alignment ss:Horizontal=""left"" ss:Vertical=""centre""/>")
                PrintLine(1, "<Font x:Family=""Swiss""/>")
                PrintLine(1, "</Style>")
                PrintLine(1, "</Styles>")
            Else
                objStreamReader = File.OpenText(FileName)
                lsTextContent = objStreamReader.ReadToEnd()
                lsTextContent = lsTextContent.ToString.Replace("</Workbook>", "")
                objStreamReader.Close()
                FileOpen(1, FileName, OpenMode.Output)
                PrintLine(1, lsTextContent.ToString)
            End If

            PrintLine(1, "<Worksheet ss:Name=""" & SheetName & """>")

            If Header1 <> "" Then n += 1
            If Header2 <> "" Then n += 1
            If Header3 <> "" Then n += 1
            If Header4 <> "" Then n += 1

            If n <> 0 Then n = n + 1

            PrintLine(1, "<Table ss:ExpandedColumnCount=" & Chr(34) & FlexGrid.Cols + n + 1 & Chr(34) & " " & _
                         "ss:ExpandedRowCount=" & Chr(34) & FlexGrid.Rows + n + 1 & Chr(34) & ">")

            If n <> 0 Then
                If Header1 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header1 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header2 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header2 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header3 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header3 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header4 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header4 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                PrintLine(1, "<Row></Row>")
            End If

            'PrintLine(1, "<Table ss:ExpandedColumnCount=" & Chr(34) & FlexGrid.Cols + n + 1 & Chr(34) & " " & _
            '             "ss:ExpandedRowCount=" & Chr(34) & FlexGrid.Rows + n + 1 & Chr(34) & ">")

            For Row = 0 To FlexGrid.FixedRows - 1
                PrintLine(1, "<Row>")

                For Col = 0 To FlexGrid.Cols - 1
                    If FlexGrid.FixedRows > 1 Then
                        PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & FlexGrid.get_TextMatrix(Row, Col) & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""s1""><Data ss:Type=""String"" x:Ticked=""1"">" & FlexGrid.get_TextMatrix(Row, Col) & "</Data></Cell>")
                    End If
                Next Col

                PrintLine(1, "</Row>")
            Next Row

            If PlainFlag = True Then
                lsStyle = "s4"
            Else
                lsStyle = "s2"
            End If

            For Row = FlexGrid.FixedRows To FlexGrid.Rows - 1
                PrintLine(1, "<Row>")
                For Col = 0 To FlexGrid.Cols - 1
                    If FlexGrid.get_ColAlignment(Col) <> 7 Then
                        PrintLine(1, "<Cell ss:StyleID=""" & lsStyle & """><Data ss:Type=""String"" x:Ticked=""1"">" & FlexGrid.get_TextMatrix(Row, Col) & "</Data></Cell>")
                    ElseIf IsNumeric(FlexGrid.get_TextMatrix(Row, Col)) = True Then
                        PrintLine(1, "<Cell ss:StyleID=""" & lsStyle & """><Data ss:Type=""Number"">" & FlexGrid.get_TextMatrix(Row, Col) & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""" & lsStyle & """><Data ss:Type=""String"" x:Ticked=""1"">" & FlexGrid.get_TextMatrix(Row, Col) & "</Data></Cell>")
                    End If
                Next Col
                PrintLine(1, "</Row>")
            Next Row

            PrintLine(1, "</Table>")
            PrintLine(1, "</Worksheet>")
            PrintLine(1, "</Workbook>")

            FileClose(1)

            If ShowFlag = True Then ShellExecute(frmMain.Handle.ToInt32, "open", FileName, "", "0", SW_SHOWNORMAL)
        Catch ex As Exception
            FileClose(1)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SeparatorToExcel(ByVal SourceFileName As String, ByVal ExcelFileName As String, ByVal SheetName As String, ByVal Separator As String, Optional ByVal StoreasNum As String = "")

        Dim objStreamReader As StreamReader
        Dim objApplication As New Excel.Application
        Dim objBooks As Excel.Workbooks
        Dim objWorkBook As Excel.Workbook
        Dim objWorkSheet As Excel.Worksheet
        Dim NumericCols() As String
        Dim txt As String
        Dim SplitTxt() As String
        Dim lsRow As Long, lsCol As Integer, TotCol As Integer, TotSheets As Integer

        NumericCols = Split(StoreasNum, "|")

        If File.Exists(ExcelFileName) = False Then
            objBooks = objApplication.Workbooks
            objWorkBook = objBooks.Add()
            objWorkSheet = objApplication.Worksheets.Add()
            objWorkSheet.Name = SheetName
            objWorkBook.SaveAs(ExcelFileName, 1)
        Else
            objBooks = objApplication.Workbooks
            objWorkBook = objBooks.Open(ExcelFileName, False, False)
            TotSheets = objWorkBook.Sheets.Count
            While TotSheets > 0
                objWorkSheet = objWorkBook.Sheets(TotSheets)
                If objWorkSheet.Name = SheetName Then
                    SheetName = SheetName & "+"
                    TotSheets = objWorkBook.Sheets.Count
                Else
                    TotSheets = TotSheets - 1
                End If
            End While
            objWorkSheet = objApplication.Worksheets.Add()
            objWorkSheet.Name = SheetName
        End If

        objApplication.Visible = True
        objStreamReader = File.OpenText(SourceFileName.Trim)

        While objStreamReader.Peek <> -1
            txt = objStreamReader.ReadLine
            SplitTxt = Split(txt, Separator)
            TotCol = UBound(SplitTxt)
            lsRow = lsRow + 1
            For lsCol = 0 To TotCol
                If IsNumericFldCol(lsCol + 1, NumericCols) = False Then
                    objWorkSheet.Cells(lsRow, lsCol + 1).value = "'" & CStr(SplitTxt(lsCol) & "")
                Else
                    objWorkSheet.Cells(lsRow, lsCol + 1).value = CStr(SplitTxt(lsCol) & "")
                End If
                objWorkSheet.Cells(lsRow, lsCol + 1).Borders.ColorIndex = 56
                objWorkSheet.Cells(lsRow, lsCol + 1).Show()
            Next
        End While

        For lsCol = 1 To TotCol + 1
            objWorkSheet.Columns(lsCol).Autofit()
            If objWorkSheet.Columns(lsCol).ColumnWidth > 40 Then
                objWorkSheet.Columns(lsCol).ColumnWidth = 40
                objWorkSheet.Columns(lsCol).WrapText = True
            End If
        Next

        objWorkBook.Save()
        'NAR(objWorkSheet)
        objWorkBook.Close(False)
        'NAR(objWorkBook)
        objBooks.Close()
        'NAR(objBooks)
        objApplication.Quit()
        'NAR(objApplication)
        'GC.Collect()
        'GC.WaitForPendingFinalizers()
        MsgBox("Created Successfully ", MsgBoxStyle.Information)
    End Sub

    Public Sub PrintDGridXML(ByVal dgrid As DataGridView, ByVal FileName As String, Optional ByVal SheetName As String = "Report", Optional ByVal StoreasNum As String = "", Optional ByVal HeaderTxt As String = "")
        Dim objDataTable As New Data.DataTable
        Dim TotCol As Integer, Col As Integer, Row As Integer
        Dim objStreamReader As StreamReader
        Dim lsTextContent As String
        Dim NumericCols() As String
        Dim lsHeaderTxt() As String
        Dim i As Integer

        NumericCols = Split(StoreasNum, "|")
        HeaderTxt = HeaderTxt.Replace(Chr(10), "")
        lsHeaderTxt = Split(HeaderTxt, Chr(13))

        Try

            objDataTable = dgrid.DataSource
            TotCol = objDataTable.Columns.Count
            If File.Exists(FileName) Then File.Delete(FileName)

            If File.Exists(FileName) = False Then
                FileOpen(1, FileName, OpenMode.Output)

                PrintLine(1, "<?xml version=""1.0"" encoding=""utf-8""?>")
                PrintLine(1, "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

                PrintLine(1, "<Styles>")
                PrintLine(1, "<Style ss:ID=""s1"">")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "<Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s2"">")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s3"">")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "</Style>")
                PrintLine(1, "</Styles>")
            Else
                objStreamReader = File.OpenText(FileName)
                lsTextContent = objStreamReader.ReadToEnd()
                lsTextContent = Replace(lsTextContent.ToString, "</Workbook>", "")
                objStreamReader.Close()
                FileOpen(1, FileName, OpenMode.Output)
                PrintLine(1, lsTextContent.ToString)
            End If

            PrintLine(1, "<Worksheet ss:Name=""" & SheetName & """>")
            PrintLine(1, "<Table>")

            If HeaderTxt <> "" Then
                For i = 0 To lsHeaderTxt.Length - 1
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:MergeAcross=" & Chr(34) & TotCol - 1 & Chr(34) & " ss:StyleID=""s3""><Data ss:Type=""String"">" & lsHeaderTxt(i) & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                Next i

                PrintLine(1, "<Row>")
                PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String""> </Data></Cell>")
                PrintLine(1, "</Row>")
            End If

            PrintLine(1, "<Row>")
            For Col = 1 To TotCol
                PrintLine(1, "<Cell ss:StyleID=""s1""><Data ss:Type=""String"">" & objDataTable.Columns(Col - 1).Caption.ToString & "</Data></Cell>")
            Next
            PrintLine(1, "</Row>")

            For Row = 0 To objDataTable.Rows.Count - 1
                PrintLine(1, "<Row>")
                For Col = 1 To TotCol
                    If IsNumericFldCol(Col, NumericCols) = False Then
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"" x:Ticked=""1"">" & objDataTable.Rows(Row).Item(Col - 1).ToString & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""Number"">" & objDataTable.Rows(Row).Item(Col - 1).ToString & "</Data></Cell>")
                    End If
                Next
                PrintLine(1, "</Row>")
            Next

            PrintLine(1, "</Table>")
            PrintLine(1, "</Worksheet>")
            PrintLine(1, "</Workbook>")

            FileClose(1)
            Call ShellExecute(frmMain.Handle.ToInt32, "open", FileName, "", "0", SW_SHOWNORMAL)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function IsNumericFldCol(ByVal ColPosition As Integer, ByVal NumericCols() As String) As Boolean
        Dim Temp As Integer
        For Temp = 0 To UBound(NumericCols)
            If ColPosition = Val(NumericCols(Temp)) Then
                IsNumericFldCol = True
                Exit Function
            End If
        Next Temp
        IsNumericFldCol = False
    End Function
    'Func For Exporting FlexGrid (Having merged Cell) To Excel using XML
    Private Class FlexCell
        Public CellFlag As String = ""
        Public MergeRow As Integer = 0
        Public MergeCol As Integer = 0
    End Class

    'Export FlexGrid To Excel using XML
    Public Sub PrintFGridXMLMerge(ByVal dgrid As AxMSFlexGridLib.AxMSFlexGrid, ByVal FileName As String, Optional ByVal SheetName As String = "Report")
        Dim objDataTable As New Data.DataTable
        Dim TotCol As Integer, Col As Integer, Row As Integer
        Dim objStreamReader As StreamReader
        Dim lsTextContent As String

        Dim Header(,) As FlexCell
        Dim RowStart(,) As Integer

        Dim i As Integer, j As Integer
        Dim lnCurrCol As Integer, lnCurrRow As Integer, lsCurrFlag As String
        Dim lsValue As String
        Dim lsNxtValue As String
        Dim lsTxt As String = ""

        Try
            ReDim Header(dgrid.FixedRows, dgrid.Cols)
            ReDim RowStart(dgrid.FixedRows, dgrid.Cols)

            'objDataTable = dgrid.DataSource
            TotCol = dgrid.Cols

            If File.Exists(FileName) = True Then File.Delete(FileName)

            If File.Exists(FileName) = False Then

                FileOpen(1, FileName, OpenMode.Output)

                PrintLine(1, "<?xml version=""1.0"" encoding=""utf-8""?>")
                PrintLine(1, "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

                PrintLine(1, "<Styles>")
                PrintLine(1, "<Style ss:ID=""s1"">")
                PrintLine(1, "<Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "<Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s2"">")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "</Styles>")
            Else
                objStreamReader = File.OpenText(FileName)
                lsTextContent = objStreamReader.ReadToEnd()
                lsTextContent = lsTextContent.ToString.Replace("</Workbook>", "")
                objStreamReader.Close()
                FileOpen(1, FileName, OpenMode.Output)
                PrintLine(1, lsTextContent.ToString)
            End If

            With dgrid
                For i = 0 To .FixedRows - 1
                    For j = 0 To .Cols - 1
                        RowStart(i, j) = 0
                        Header(i, j) = New FlexCell
                    Next j
                Next i

                For i = 0 To .FixedRows - 1
                    For j = 0 To .Cols - 1
                        lsValue = .get_TextMatrix(i, j)
                        lsCurrFlag = Header(i, j).CellFlag

                        If lsCurrFlag = "" Then
                            lnCurrRow = i
                            lnCurrCol = j
                            lsCurrFlag = "Y"

                            Header(i, j).CellFlag = lsCurrFlag
                            Header(i, j).MergeRow = 0
                            Header(i, j).MergeCol = 0

                            For Col = j + 1 To .Cols - 1
                                lsNxtValue = .get_TextMatrix(i, Col)

                                If lsValue <> lsNxtValue Or Header(i, Col).CellFlag <> "" Then
                                    Exit For
                                Else
                                    lnCurrCol += 1
                                    Header(i, j).MergeCol = lnCurrCol.ToString

                                    Header(i, Col).CellFlag = "N"
                                    Header(i, Col).MergeRow = 0
                                    Header(i, Col).MergeCol = 0
                                End If
                            Next Col

                            For Row = i + 1 To .FixedRows - 1
                                lsNxtValue = .get_TextMatrix(Row, j)

                                If lsValue <> lsNxtValue Then
                                    Exit For
                                Else
                                    lnCurrRow += 1
                                    Header(i, j).MergeRow = lnCurrRow.ToString

                                    Header(Row, j).CellFlag = "N"
                                    Header(Row, j).MergeRow = 0
                                    Header(Row, j).MergeCol = 0
                                End If
                            Next Row

                            Header(i, j).MergeRow = lnCurrRow - i
                            Header(i, j).MergeCol = lnCurrCol - j

                            For Row = i + 1 To lnCurrRow
                                If lnCurrCol <> 0 Then
                                    If RowStart(Row, lnCurrCol - 1) <> 0 Then RowStart(Row, lnCurrCol - 1) = 0
                                    If lnCurrCol < .Cols - 1 Then RowStart(Row, lnCurrCol + 1) = lnCurrCol + 1
                                Else
                                    If lnCurrCol < .Cols - 1 Then RowStart(Row, lnCurrCol + 1) = 1
                                End If

                                For Col = j + 1 To lnCurrCol
                                    Header(Row, Col).CellFlag = "N"
                                    Header(Row, Col).MergeRow = 0
                                    Header(Row, Col).MergeCol = 0
                                Next Col
                            Next Row

                            'If j = 0 And i < .FixedRows - 1 Then RowStart(i + 1) = lnCurrCol
                        End If
                    Next j
                Next i
            End With

            PrintLine(1, "<Worksheet ss:Name=""" & SheetName & """>")
            PrintLine(1, "<Table ss:ExpandedColumnCount=" & Chr(34) & dgrid.Cols + 1 & Chr(34) & " " & _
                         "ss:ExpandedRowCount=" & Chr(34) & dgrid.Rows + 1 & Chr(34) & ">")

            For Row = 0 To dgrid.FixedRows - 1
                PrintLine(1, "<Row>")

                For Col = 0 To dgrid.Cols - 1
                    If Header(Row, Col).CellFlag = "Y" Then
                        lsTxt = ""
                        lsTxt &= "<Cell "

                        If Row <> 0 And Col <> 0 Then
                            'lsTxt &= IIf(RowStart(Row, Col) <> 0 Or Header(Row - 1, Col - 1).MergeRow <> 0, "ss:Index=" & Chr(34) & RowStart(Row, Col) + 2 & Chr(34) & " ", "")
                            lsTxt &= IIf(RowStart(Row, Col) <> 0, "ss:Index=" & Chr(34) & RowStart(Row, Col) + 1 & Chr(34) & " ", "")
                        End If

                        lsTxt &= IIf(Header(Row, Col).MergeCol = 0, "", "ss:MergeAcross=" & Chr(34) & Header(Row, Col).MergeCol & Chr(34) & " ")
                        lsTxt &= IIf(Header(Row, Col).MergeRow = 0, "", "ss:MergeDown=" & Chr(34) & Header(Row, Col).MergeRow & Chr(34) & " ")
                        lsTxt &= "ss:StyleID=""s1"">"
                        lsTxt &= "<Data ss:Type=""String"">" & dgrid.get_TextMatrix(Row, Col) & "</Data></Cell>"

                        PrintLine(1, lsTxt)
                    End If
                Next Col

                PrintLine(1, "</Row>")
            Next Row

            For Row = dgrid.FixedRows To dgrid.Rows - 1
                PrintLine(1, "<Row>")
                For Col = 0 To dgrid.Cols - 1
                    If dgrid.get_ColAlignment(Col) <> 7 Or IsNumeric(dgrid.get_TextMatrix(Row, Col)) = False Then
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"" x:Ticked=""1"">" & dgrid.get_TextMatrix(Row, Col) & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""Number"">" & dgrid.get_TextMatrix(Row, Col) & "</Data></Cell>")
                    End If
                    'Else
                    'PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"">" & dgrid.get_TextMatrix(Row, Col) & "</Data></Cell>")
                    'End If
                Next
                PrintLine(1, "</Row>")
            Next

            PrintLine(1, "</Table>")
            PrintLine(1, "</Worksheet>")
            PrintLine(1, "</Workbook>")

            FileClose(1)

            Call ShellExecute(frmMain.Handle.ToInt32, "open", FileName, "", "0", SW_SHOWNORMAL)
        Catch ex As Exception
            FileClose(1)
            MsgBox(ex.Message)
        End Try
    End Sub
    'For Exporting DataGrid to XL
    Public Sub PrintDGridXML(ByVal dgrid As DataGrid, ByVal FileName As String, Optional ByVal SheetName As String = "Report", Optional ByVal StoreasNum As String = "")
        Dim objDataTable As New Data.DataTable
        Dim TotCol As Integer, Col As Integer, Row As Integer
        Dim objStreamReader As StreamReader
        Dim lsTextContent As String
        Dim NumericCols() As String
        NumericCols = Split(StoreasNum, "|")

        Try

            objDataTable = dgrid.DataSource
            TotCol = objDataTable.Columns.Count
            If File.Exists(FileName) Then File.Delete(FileName)
            If File.Exists(FileName) = False Then

                FileOpen(1, FileName, OpenMode.Output)

                PrintLine(1, "<?xml version=""1.0"" encoding=""utf-8""?>")
                PrintLine(1, "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

                PrintLine(1, "<Styles>")
                PrintLine(1, "<Style ss:ID=""s1"">")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "<Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s2"">")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "</Styles>")
            Else
                objStreamReader = File.OpenText(FileName)
                lsTextContent = objStreamReader.ReadToEnd()
                lsTextContent = Replace(lsTextContent.ToString, "</Workbook>", "")
                objStreamReader.Close()
                FileOpen(1, FileName, OpenMode.Output)
                PrintLine(1, lsTextContent.ToString)
            End If

            PrintLine(1, "<Worksheet ss:Name=""" & SheetName & """>")
            PrintLine(1, "<Table>")

            PrintLine(1, "<Row>")
            For Col = 1 To TotCol
                PrintLine(1, "<Cell ss:StyleID=""s1""><Data ss:Type=""String"">" & objDataTable.Columns(Col - 1).Caption.ToString & "</Data></Cell>")
            Next
            PrintLine(1, "</Row>")

            For Row = 0 To objDataTable.Rows.Count - 1
                PrintLine(1, "<Row>")
                For Col = 1 To TotCol
                    If IsNumericFldCol(Col, NumericCols) = False Then
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"" x:Ticked=""1"">" & objDataTable.Rows(Row).Item(Col - 1).ToString & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""Number"">" & objDataTable.Rows(Row).Item(Col - 1).ToString & "</Data></Cell>")
                    End If
                Next
                PrintLine(1, "</Row>")
            Next

            PrintLine(1, "</Table>")
            PrintLine(1, "</Worksheet>")
            PrintLine(1, "</Workbook>")

            FileClose(1)
            Call ShellExecute(frmMain.Handle.ToInt32, "open", FileName, "", "0", SW_SHOWNORMAL)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub FormatSheet(ByVal ExcelFileName As String, ByVal SheetName As String)
        Dim objApplication As New Excel.Application
        Dim objBooks As Excel.Workbooks
        Dim objWorkBook As Excel.Workbook
        Dim objWorkSheet As Excel.Worksheet
        Dim objRange As Excel.Range
        Dim a() As Short = {1, 2}
        Dim i As Integer

        Try
            If File.Exists(ExcelFileName) = False Then Exit Sub

            objBooks = objApplication.Workbooks
            objWorkBook = objBooks.Open(ExcelFileName, False, False)
            objWorkSheet = objWorkBook.Sheets(SheetName)

            objApplication.Visible = True

            For i = 1 To 256
                If objWorkSheet.Cells(1, i).Value <> "" Then
                    Select Case objWorkSheet.Cells(2, i).NumberFormat
                        Case "@", "0", "0.00"
                            objWorkSheet.Columns(i).cells.NumberFormat = "@"

                            objRange = objWorkSheet.Columns(i)
                            objRange.TextToColumns(objRange, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote, , , , , , , , a, , )
                        Case Else
                            If IsDate(objWorkSheet.Cells(2, i).ToString()) = False Then
                                objRange = objWorkSheet.Columns(i)
                                objRange.TextToColumns(objRange, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote, , , , , , , , a, , )
                            End If
                    End Select
                Else
                    Exit For
                End If
            Next i

            objWorkBook.Save()
            objWorkBook.Close()
            objBooks.Close()

            objApplication.Quit()

            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objApplication)

            GC.Collect()
            GC.WaitForPendingFinalizers()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Public Sub gpOpenFile(ByVal FileName As String)
        Call ShellExecute(frmMain.Handle.ToInt32, "open", FileName, "", "0", SW_SHOWNORMAL)
    End Sub

    Public Sub PrintFGridXML(ByVal FlexGrid As AxMSFlexGridLib.AxMSFlexGrid, ByVal FileName As String, _
                             ByVal SheetName As String, _
                             ByVal Header1 As String, _
                             ByVal Header2 As String, _
                             ByVal Header3 As String, _
                             ByVal Header4 As String, _
                             ByVal Header5 As String, _
                             ByVal Header6 As String, _
                             ByVal Header7 As String, _
                             ByVal Header8 As String, _
                             ByVal Header9 As String, _
                             Optional ByVal ShowFlag As Boolean = True, _
                             Optional ByVal DelFlag As Boolean = True, _
                             Optional ByVal PlainFlag As Boolean = False)

        Dim objDataTable As New Data.DataTable
        Dim Col As Integer, Row As Integer
        Dim objStreamReader As StreamReader
        Dim lsTextContent As String

        Dim n As Integer = 0
        Dim lsTxt As String = ""
        Dim lsStyle As String = ""

        Try
            If File.Exists(FileName) = True And DelFlag = True Then File.Delete(FileName)

            If File.Exists(FileName) = False Then
                FileOpen(1, FileName, OpenMode.Append)

                PrintLine(1, "<?xml version=""1.0"" encoding=""utf-8""?>")
                PrintLine(1, "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

                PrintLine(1, "<Styles>")
                PrintLine(1, "<Style ss:ID=""s1"">")
                PrintLine(1, "<Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "<Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s2"">")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s3"">")
                'PrintLine(1, "<Alignment ss:Horizontal=""left"" ss:Vertical=""centre""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s4"">")
                'PrintLine(1, "<Alignment ss:Horizontal=""left"" ss:Vertical=""centre""/>")
                PrintLine(1, "<Font x:Family=""Swiss""/>")
                PrintLine(1, "</Style>")
                PrintLine(1, "</Styles>")
            Else
                objStreamReader = File.OpenText(FileName)
                lsTextContent = objStreamReader.ReadToEnd()
                lsTextContent = lsTextContent.ToString.Replace("</Workbook>", "")
                objStreamReader.Close()
                FileOpen(1, FileName, OpenMode.Output)
                PrintLine(1, lsTextContent.ToString)
            End If

            PrintLine(1, "<Worksheet ss:Name=""" & SheetName & """>")

            If Header1 <> "" Then n += 1
            If Header2 <> "" Then n += 1
            If Header3 <> "" Then n += 1
            If Header4 <> "" Then n += 1
            If Header5 <> "" Then n += 1
            If Header6 <> "" Then n += 1
            If Header7 <> "" Then n += 1
            If Header8 <> "" Then n += 1
            If Header9 <> "" Then n += 1

            If n <> 0 Then n = n + 1

            PrintLine(1, "<Table ss:ExpandedColumnCount=" & Chr(34) & FlexGrid.Cols + n + 1 & Chr(34) & " " & _
                         "ss:ExpandedRowCount=" & Chr(34) & FlexGrid.Rows + n + 1 & Chr(34) & ">")

            If n <> 0 Then
                If Header1 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header1 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header2 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header2 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header3 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header3 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header4 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header4 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header5 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header5 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header6 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header6 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header7 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header7 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header8 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header8 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header9 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header9 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                PrintLine(1, "<Row></Row>")
            End If

            'PrintLine(1, "<Table ss:ExpandedColumnCount=" & Chr(34) & FlexGrid.Cols + n + 1 & Chr(34) & " " & _
            '             "ss:ExpandedRowCount=" & Chr(34) & FlexGrid.Rows + n + 1 & Chr(34) & ">")

            For Row = 0 To FlexGrid.FixedRows - 1
                PrintLine(1, "<Row>")

                For Col = 0 To FlexGrid.Cols - 1
                    lsTxt = FlexGrid.get_TextMatrix(Row, Col)
                    lsTxt = lsTxt.Replace("<", "< ")
                    lsTxt = lsTxt.Replace(">", " >")

                    If FlexGrid.FixedRows > 1 Then
                        PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""s1""><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    End If
                Next Col

                PrintLine(1, "</Row>")
            Next Row

            If PlainFlag = True Then
                lsStyle = "s4"
            Else
                lsStyle = "s2"
            End If

            For Row = FlexGrid.FixedRows To FlexGrid.Rows - 1
                PrintLine(1, "<Row>")
                For Col = 0 To FlexGrid.Cols - 1
                    lsTxt = FlexGrid.get_TextMatrix(Row, Col)
                    lsTxt = lsTxt.Replace("<", "< ")
                    lsTxt = lsTxt.Replace(">", " >")

                    If FlexGrid.get_ColAlignment(Col) <> 7 Then
                        PrintLine(1, "<Cell ss:StyleID=""" & lsStyle & """><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    ElseIf IsNumeric(FlexGrid.get_TextMatrix(Row, Col)) = True Then
                        PrintLine(1, "<Cell ss:StyleID=""" & lsStyle & """><Data ss:Type=""Number"">" & lsTxt & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""" & lsStyle & """><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    End If
                Next Col
                PrintLine(1, "</Row>")
            Next Row

            PrintLine(1, "</Table>")
            PrintLine(1, "</Worksheet>")
            PrintLine(1, "</Workbook>")

            FileClose(1)

            If ShowFlag = True Then ShellExecute(frmMain.Handle.ToInt32, "open", FileName, "", "0", SW_SHOWNORMAL)
        Catch ex As Exception
            FileClose(1)
            ' objMail.GF_Mail(gsMailFrom, gsMailTo, gsMailSub, ex.Message, gsFormName, "PrintFGridXML")
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub PrintFGridXMLMerge(ByVal dgrid As AxMSFlexGridLib.AxMSFlexGrid, ByVal FileName As String, ByVal SheetName As String, ByVal DelFlag As Boolean, Optional ByVal ShowFlag As Boolean = False)
        Dim objDataTable As New Data.DataTable
        Dim TotCol As Integer, Col As Integer, Row As Integer
        Dim objStreamReader As StreamReader
        Dim lsTextContent As String

        Dim Header(,) As FlexCell
        Dim RowStart(,) As Integer

        Dim i As Integer, j As Integer
        Dim lnCurrCol As Integer, lnCurrRow As Integer, lsCurrFlag As String
        Dim lsValue As String
        Dim lsNxtValue As String
        Dim lsTxt As String = ""

        Try
            ReDim Header(dgrid.FixedRows, dgrid.Cols)
            ReDim RowStart(dgrid.FixedRows, dgrid.Cols)

            'objDataTable = dgrid.DataSource
            TotCol = dgrid.Cols

            If File.Exists(FileName) = True And DelFlag = True Then File.Delete(FileName)

            If File.Exists(FileName) = False Then
                FileOpen(1, FileName, OpenMode.Output)

                PrintLine(1, "<?xml version=""1.0"" encoding=""utf-8""?>")
                PrintLine(1, "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

                PrintLine(1, "<Styles>")
                PrintLine(1, "<Style ss:ID=""s1"">")
                PrintLine(1, "<Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "<Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s2"">")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "</Styles>")
            Else
                objStreamReader = File.OpenText(FileName)
                lsTextContent = objStreamReader.ReadToEnd()
                lsTextContent = lsTextContent.ToString.Replace("</Workbook>", "")
                objStreamReader.Close()
                FileOpen(1, FileName, OpenMode.Output)
                PrintLine(1, lsTextContent.ToString)
            End If

            With dgrid
                For i = 0 To .FixedRows - 1
                    For j = 0 To .Cols - 1
                        RowStart(i, j) = 0
                        Header(i, j) = New FlexCell
                    Next j
                Next i

                For i = 0 To .FixedRows - 1
                    For j = 0 To .Cols - 1
                        lsValue = .get_TextMatrix(i, j)
                        lsCurrFlag = Header(i, j).CellFlag

                        If lsCurrFlag = "" Then
                            lnCurrRow = i
                            lnCurrCol = j
                            lsCurrFlag = "Y"

                            Header(i, j).CellFlag = lsCurrFlag
                            Header(i, j).MergeRow = 0
                            Header(i, j).MergeCol = 0

                            For Col = j + 1 To .Cols - 1
                                lsNxtValue = .get_TextMatrix(i, Col)

                                If lsValue <> lsNxtValue Or Header(i, Col).CellFlag <> "" Then
                                    Exit For
                                Else
                                    lnCurrCol += 1
                                    Header(i, j).MergeCol = lnCurrCol.ToString

                                    Header(i, Col).CellFlag = "N"
                                    Header(i, Col).MergeRow = 0
                                    Header(i, Col).MergeCol = 0
                                End If
                            Next Col

                            For Row = i + 1 To .FixedRows - 1
                                lsNxtValue = .get_TextMatrix(Row, j)

                                If lsValue <> lsNxtValue Then
                                    Exit For
                                Else
                                    lnCurrRow += 1
                                    Header(i, j).MergeRow = lnCurrRow.ToString

                                    Header(Row, j).CellFlag = "N"
                                    Header(Row, j).MergeRow = 0
                                    Header(Row, j).MergeCol = 0
                                End If
                            Next Row

                            Header(i, j).MergeRow = lnCurrRow - i
                            Header(i, j).MergeCol = lnCurrCol - j

                            For Row = i + 1 To lnCurrRow
                                If lnCurrCol <> 0 Then
                                    If RowStart(Row, lnCurrCol - 1) <> 0 Then RowStart(Row, lnCurrCol - 1) = 0
                                    If lnCurrCol < .Cols - 1 Then RowStart(Row, lnCurrCol + 1) = lnCurrCol + 1
                                Else
                                    If lnCurrCol < .Cols - 1 Then RowStart(Row, lnCurrCol + 1) = 1
                                End If

                                For Col = j + 1 To lnCurrCol
                                    Header(Row, Col).CellFlag = "N"
                                    Header(Row, Col).MergeRow = 0
                                    Header(Row, Col).MergeCol = 0
                                Next Col
                            Next Row

                            'If j = 0 And i < .FixedRows - 1 Then RowStart(i + 1) = lnCurrCol
                        End If
                    Next j
                Next i
            End With

            PrintLine(1, "<Worksheet ss:Name=""" & SheetName & """>")
            PrintLine(1, "<Table ss:ExpandedColumnCount=" & Chr(34) & dgrid.Cols + 1 & Chr(34) & " " & _
                         "ss:ExpandedRowCount=" & Chr(34) & dgrid.Rows + 1 & Chr(34) & ">")

            For Row = 0 To dgrid.FixedRows - 1
                PrintLine(1, "<Row>")

                For Col = 0 To dgrid.Cols - 1
                    If Header(Row, Col).CellFlag = "Y" Then
                        lsTxt = ""
                        lsTxt &= "<Cell "

                        If Row <> 0 And Col <> 0 Then
                            'lsTxt &= IIf(RowStart(Row, Col) <> 0 Or Header(Row - 1, Col - 1).MergeRow <> 0, "ss:Index=" & Chr(34) & RowStart(Row, Col) + 2 & Chr(34) & " ", "")
                            lsTxt &= IIf(RowStart(Row, Col) <> 0, "ss:Index=" & Chr(34) & RowStart(Row, Col) + 1 & Chr(34) & " ", "")
                        End If

                        lsTxt &= IIf(Header(Row, Col).MergeCol = 0, "", "ss:MergeAcross=" & Chr(34) & Header(Row, Col).MergeCol & Chr(34) & " ")
                        lsTxt &= IIf(Header(Row, Col).MergeRow = 0, "", "ss:MergeDown=" & Chr(34) & Header(Row, Col).MergeRow & Chr(34) & " ")
                        lsTxt &= "ss:StyleID=""s1"">"
                        lsTxt &= "<Data ss:Type=""String"">" & dgrid.get_TextMatrix(Row, Col) & "</Data></Cell>"

                        PrintLine(1, lsTxt)
                    End If
                Next Col

                PrintLine(1, "</Row>")
            Next Row

            For Row = dgrid.FixedRows To dgrid.Rows - 1
                PrintLine(1, "<Row>")
                For Col = 0 To dgrid.Cols - 1
                    lsTxt = dgrid.get_TextMatrix(Row, Col)
                    lsTxt = Replace(lsTxt, "<", "< ")
                    lsTxt = Replace(lsTxt, ">", " >")

                    If dgrid.get_ColAlignment(Col) <> 7 Or IsNumeric(dgrid.get_TextMatrix(Row, Col)) = False Then
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    ElseIf IsNumeric(dgrid.get_TextMatrix(Row, Col)) = True Then
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""Number"">" & lsTxt & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    End If
                    'Else
                    'PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"">" & dgrid.get_TextMatrix(Row, Col) & "</Data></Cell>")
                    'End If
                Next
                PrintLine(1, "</Row>")
            Next

            PrintLine(1, "</Table>")
            PrintLine(1, "</Worksheet>")
            PrintLine(1, "</Workbook>")

            FileClose(1)

            If ShowFlag = True Then Call ShellExecute(frmMain.Handle.ToInt32, "open", FileName, "", "0", SW_SHOWNORMAL)
        Catch ex As Exception
            FileClose(1)
            'objMail.GF_Mail(gsMailFrom, gsMailTo, gsMailSub, ex.Message, gsFormName, "PrintFGridXMLMerge")
            MsgBox(ex.Message)
        End Try
    End Sub

    'For Exporting DataGridView to XL
    Public Sub PrintDGViewXML(ByVal dgrid As DataGridView, ByVal FileName As String, Optional ByVal SheetName As String = "Report", Optional ByVal StoreasNum As String = "", Optional ByVal DeleteFlag As Boolean = True, Optional ByVal ShowFlag As Boolean = False)
        Dim objDataTable As New Data.DataTable
        Dim TotCol As Integer, Col As Integer, Row As Integer
        Dim objStreamReader As StreamReader
        Dim lsTxt As String
        Dim lsTextContent As String
        Dim NumericCols() As String
        NumericCols = Split(StoreasNum, "|")

        Try

            objDataTable = dgrid.DataSource
            TotCol = objDataTable.Columns.Count
            If DeleteFlag = True Then
                If File.Exists(FileName) Then File.Delete(FileName)
            End If
            If File.Exists(FileName) = False Then

                FileOpen(1, FileName, OpenMode.Output)

                PrintLine(1, "<?xml version=""1.0"" encoding=""utf-8""?>")
                PrintLine(1, "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

                PrintLine(1, "<Styles>")
                PrintLine(1, "<Style ss:ID=""s1"">")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "<Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s2"">")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "</Styles>")
            Else
                objStreamReader = File.OpenText(FileName)
                lsTextContent = objStreamReader.ReadToEnd()
                lsTextContent = Replace(lsTextContent.ToString, "</Workbook>", "")
                objStreamReader.Close()
                FileOpen(1, FileName, OpenMode.Output)
                PrintLine(1, lsTextContent.ToString)
            End If

            PrintLine(1, "<Worksheet ss:Name=""" & SheetName & """>")
            PrintLine(1, "<Table>")

            PrintLine(1, "<Row>")
            For Col = 1 To TotCol
                PrintLine(1, "<Cell ss:StyleID=""s1""><Data ss:Type=""String"">" & objDataTable.Columns(Col - 1).Caption.ToString & "</Data></Cell>")
            Next
            PrintLine(1, "</Row>")

            For Row = 0 To objDataTable.Rows.Count - 1
                PrintLine(1, "<Row>")
                For Col = 1 To TotCol
                    lsTxt = Replace(objDataTable.Rows(Row).Item(Col - 1).ToString, ">", " >")
                    lsTxt = Replace(lsTxt, "<", "< ")

                    If IsNumericFldCol(Col, NumericCols) = False Then
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""s2""><Data ss:Type=""Number"">" & lsTxt & "</Data></Cell>")
                    End If
                Next
                PrintLine(1, "</Row>")
            Next

            PrintLine(1, "</Table>")
            PrintLine(1, "</Worksheet>")
            PrintLine(1, "</Workbook>")

            FileClose(1)

            If ShowFlag = True Then
                Call ShellExecute(frmMain.Handle.ToInt32, "open", FileName, "", "0", SW_SHOWNORMAL)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub PrintFGridXML(ByVal FlexGrid As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid, ByVal FileName As String, _
                                 Optional ByVal SheetName As String = "Report", _
                                 Optional ByVal Header1 As String = "", _
                                 Optional ByVal Header2 As String = "", _
                                 Optional ByVal Header3 As String = "", _
                                 Optional ByVal Header4 As String = "", _
                                 Optional ByVal ShowFlag As Boolean = True, _
                                 Optional ByVal DelFlag As Boolean = True, _
                                 Optional ByVal PlainFlag As Boolean = False)

        Dim objDataTable As New Data.DataTable
        Dim Col As Integer, Row As Integer
        Dim objStreamReader As StreamReader
        Dim lsTextContent As String

        Dim n As Integer = 0
        Dim lsTxt As String = ""
        Dim lsStyle As String = ""

        Try
            If File.Exists(FileName) = True And DelFlag = True Then File.Delete(FileName)

            If File.Exists(FileName) = False Then
                FileOpen(1, FileName, OpenMode.Append)

                PrintLine(1, "<?xml version=""1.0"" encoding=""utf-8""?>")
                PrintLine(1, "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

                PrintLine(1, "<Styles>")
                PrintLine(1, "<Style ss:ID=""s1"">")
                PrintLine(1, "<Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "<Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s2"">")
                PrintLine(1, "<Borders>")
                PrintLine(1, "<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" />")
                PrintLine(1, "<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" /> ")
                PrintLine(1, "</Borders>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s3"">")
                'PrintLine(1, "<Alignment ss:Horizontal=""left"" ss:Vertical=""centre""/>")
                PrintLine(1, "<Font x:Family=""Swiss"" ss:Bold=""1""/>")
                PrintLine(1, "</Style>")
                PrintLine(1, "<Style ss:ID=""s4"">")
                'PrintLine(1, "<Alignment ss:Horizontal=""left"" ss:Vertical=""centre""/>")
                PrintLine(1, "<Font x:Family=""Swiss""/>")
                PrintLine(1, "</Style>")
                PrintLine(1, "</Styles>")
            Else
                objStreamReader = File.OpenText(FileName)
                lsTextContent = objStreamReader.ReadToEnd()
                lsTextContent = lsTextContent.ToString.Replace("</Workbook>", "")
                objStreamReader.Close()
                FileOpen(1, FileName, OpenMode.Output)
                PrintLine(1, lsTextContent.ToString)
            End If

            PrintLine(1, "<Worksheet ss:Name=""" & SheetName & """>")

            If Header1 <> "" Then n += 1
            If Header2 <> "" Then n += 1
            If Header3 <> "" Then n += 1
            If Header4 <> "" Then n += 1

            If n <> 0 Then n = n + 1

            PrintLine(1, "<Table ss:ExpandedColumnCount=" & Chr(34) & FlexGrid.get_Cols + n + 1 & Chr(34) & " " & _
                         "ss:ExpandedRowCount=" & Chr(34) & FlexGrid.Rows + n + 1 & Chr(34) & ">")

            If n <> 0 Then
                If Header1 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header1 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header2 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header2 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header3 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header3 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                If Header4 <> "" Then
                    PrintLine(1, "<Row>")
                    PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & Header4 & "</Data></Cell>")
                    PrintLine(1, "</Row>")
                End If

                PrintLine(1, "<Row></Row>")
            End If

            'PrintLine(1, "<Table ss:ExpandedColumnCount=" & Chr(34) & FlexGrid.Cols + n + 1 & Chr(34) & " " & _
            '             "ss:ExpandedRowCount=" & Chr(34) & FlexGrid.Rows + n + 1 & Chr(34) & ">")

            For Row = 0 To FlexGrid.FixedRows - 1
                PrintLine(1, "<Row>")

                For Col = 0 To FlexGrid.get_Cols - 1
                    lsTxt = FlexGrid.get_TextMatrix(Row, Col)
                    lsTxt = lsTxt.Replace("<", "< ")
                    lsTxt = lsTxt.Replace(">", " >")

                    If FlexGrid.FixedRows > 1 Then
                        PrintLine(1, "<Cell ss:StyleID=""s3""><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""s1""><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    End If
                Next Col

                PrintLine(1, "</Row>")
            Next Row

            If PlainFlag = True Then
                lsStyle = "s4"
            Else
                lsStyle = "s2"
            End If

            For Row = FlexGrid.FixedRows To FlexGrid.Rows - 1
                PrintLine(1, "<Row>")
                For Col = 0 To FlexGrid.get_Cols - 1
                    lsTxt = FlexGrid.get_TextMatrix(Row, Col)
                    lsTxt = lsTxt.Replace("<", "< ")
                    lsTxt = lsTxt.Replace(">", " >")

                    If FlexGrid.get_ColAlignment(Col) <> 7 Then
                        PrintLine(1, "<Cell ss:StyleID=""" & lsStyle & """><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    ElseIf IsNumeric(FlexGrid.get_TextMatrix(Row, Col)) = True Then
                        PrintLine(1, "<Cell ss:StyleID=""" & lsStyle & """><Data ss:Type=""Number"">" & lsTxt & "</Data></Cell>")
                    Else
                        PrintLine(1, "<Cell ss:StyleID=""" & lsStyle & """><Data ss:Type=""String"" x:Ticked=""1"">" & lsTxt & "</Data></Cell>")
                    End If
                Next Col
                PrintLine(1, "</Row>")
            Next Row

            PrintLine(1, "</Table>")
            PrintLine(1, "</Worksheet>")
            PrintLine(1, "</Workbook>")

            FileClose(1)

            If ShowFlag = True Then ShellExecute(frmMain.Handle.ToInt32, "open", FileName, "", "0", SW_SHOWNORMAL)
        Catch ex As Exception
            FileClose(1)
            ' objMail.GF_Mail(gsMailFrom, gsMailTo, gsMailSub, ex.Message, gsFormName, "PrintFGridXML")
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ConvertXmlToExcel(ByVal SrcFileName As String, ByVal DestFileName As String)
        Dim objXL As New Excel.Application

        Try
            If File.Exists(SrcFileName) = False Then Exit Sub
            If File.Exists(DestFileName) = True Then File.Delete(DestFileName)

            objXL.Workbooks.Open(SrcFileName)
            objXL.ActiveWorkbook.SaveAs(DestFileName, 1)
            objXL.ActiveWorkbook.Close()
            objXL.Application.Quit()

            ReleaseObject(objXL)
            KillAllExcel()

            GC.Collect()
            GC.WaitForPendingFinalizers()
        Catch ex As Exception
            ' objMail.GF_Mail(gsMailFrom, gsMailTo, gsMailSub, ex.Message, gsFormName, "ConvertXmlToExcel")
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub KillAllExcel()
        Dim xlp() As Process = Process.GetProcessesByName("EXCEL")

        For Each Process As Process In xlp
            Process.Kill()
            If Process.GetProcessesByName("EXCEL").Count = 0 Then
                Exit For
            End If
        Next
    End Sub
End Module