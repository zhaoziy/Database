using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Reflection;

namespace VehicleManagement
{
	class ExcelCmd
	{
		private Microsoft.Office.Interop.Excel.Application ExcelApp;
		private Workbooks ExcelWorkbooks;
		private Workbook ExcelWorkBook;
		private Sheets ExcelSheets;
		private Worksheet ExcelWorkSheet;

		public ExcelCmd()
		{
			ExcelApp = new Microsoft.Office.Interop.Excel.Application();
			ExcelWorkbooks = ExcelApp.Workbooks;
		}

		public bool CreateOrOpenExcelFile(bool mode, string path = "")
		{
			if (mode == true)
			{
				ExcelWorkBook = ExcelWorkbooks.Add(mode);
			}
			else if (path != "")
			{
				ExcelWorkBook = ExcelWorkbooks.Add(path);
			}
			else
			{
				MessageBox.Show("路径不能为空");
				return false;
			}

			ExcelSheets = ExcelWorkBook.Sheets;
			return true;
		} ///mode为true时创建新文件，false时打开path位置的文件

		public bool GetSheetIndex(int index)
		{
			if(index > 0)
			{
				try
				{
					ExcelWorkSheet = (Worksheet)ExcelSheets.get_Item(index);
					return true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return false;
				}
			}
			else
			{
				MessageBox.Show("Index必须大于0");
				return false;
			}
			
		}  ///index是要取得的sheet的index

		public bool AddSheet(object before, object after, object num, object type)
		{
			try
			{
				ExcelApp.Worksheets.Add(before, after, num, type);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}///before,after: 确定添加位置；num：数目；type：类型

		public bool RenameSheet(int index, string Name)
		{
			try
			{
				GetSheetIndex(index);
				ExcelWorkSheet.Name = Name;
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		public bool FillCell(int row, int col, object content)
		{
			try
			{
				ExcelWorkSheet.Cells[row, col] = content;
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		public object GetCell(int row, int col)
		{
			try
			{
                return ((Range)ExcelWorkSheet.Cells[row, col]).Text.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
            }
		}

		public void SaveFile(string path)
		{
			ExcelApp.AlertBeforeOverwriting = false;
			try
			{
				ExcelWorkBook.SaveAs(path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				MessageBox.Show("保存成功");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
        }

		public void ShowOrHideForm(bool mode)
		{
			ExcelApp.Visible = mode;
		}

		public void ExitExcelApp()
		{
			try
			{
				if(ExcelWorkBook != null)
				{
					ExcelWorkBook.Close();
				}
				if(ExcelWorkbooks != null)
				{
					ExcelWorkbooks.Close();
				}
				if(ExcelApp != null)
				{
					ExcelApp.Quit();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public void CloseExcelWorkbooks()
		{
			try
			{
				if (ExcelWorkBook != null)
				{
					ExcelWorkBook.Close();
				}
				if (ExcelWorkbooks != null)
				{
					ExcelWorkbooks.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
