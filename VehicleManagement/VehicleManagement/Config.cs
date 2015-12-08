using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleManagement
{
	class Config
	{
		#region "变量定义"

		public int 汽车ID = 500;
		public int 车型 = 2;
		public int 厂商 = 6;
		public int 级别 = 7;
		public int 车身结构 = 11;
		public int 长 = 21;
		public int 宽 = 22;
		public int 高 = 23;
		public int 最高车速 = 12;
		public int 百公里加速 = 13;
		public int 综合油耗 = 17;
		public int 最小离地间隙 = 27;
		public int 轴距 = 24;
		public int 前轮距 = 25;
		public int 后轮距 = 26;
		public int 整备质量 = 28;
		public int 车门数 = 30;
		public int 座位数 = 31;
		public int 行李厢容积 = 33;
		public int 排量 = 36;
		public int 前轮胎规格 = 73;
		public int 后轮胎规格 = 74;
		public int 电动天窗 = 106;
		public int 全景天窗 = 107;
		public int 运动外观套件 = 108;
		public int 铝合金轮圈 = 109;
		public int 电动吸合门 = 110;
		public int 侧滑门 = 111;
		public int 电动后备厢 = 112;
		public int 感应后备厢 = 113;
		public int 车顶行李架 = 114;
		public int 外观颜色 = 500;

		#endregion

		public Config(string path)
		{
			ExcelCmd excelcmd = new ExcelCmd();
			excelcmd.CreateOrOpenExcelFile(false, path);
			excelcmd.SetActiveSheet(1);
			int MaxRowNum = excelcmd.GetLastRow(1);
			string[] RowName = new string[MaxRowNum];
			for (int iLoop = 0; iLoop < MaxRowNum; ++iLoop)
			{
				RowName[iLoop] = (string)excelcmd.GetCell(iLoop + 1, 1);
            }
			excelcmd.ExitExcelApp();

			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if(RowName[iLoop - 1] == "")
				{
					汽车ID = 汽车ID;
					break;
                }
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if(RowName[iLoop - 1] == "")
				{
					车型 = 车型;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "厂商")
				{
					厂商 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "级别")
				{
					级别 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "车身结构")
				{
					车身结构 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "长")
				{
					长 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "宽")
				{
					宽 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "高")
				{
					高 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "最高车速(km/h)")
				{
					最高车速 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "官方0-100km/h加速(s)")
				{
					百公里加速 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "工信部综合油耗(L/100km)")
				{
					综合油耗 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "最小离地间隙(mm)")
				{
					最小离地间隙 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "轴距(mm)")
				{
					轴距 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "前轮距(mm)")
				{
					前轮距 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "后轮距(mm)")
				{
					后轮距 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "整备质量(kg)")
				{
					整备质量 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "车门数(个)")
				{
					车门数 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "座位数(个)")
				{
					座位数 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "行李厢容积(L)")
				{
					行李厢容积 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "排量(mL)")
				{
					排量 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "前轮胎规格")
				{
					前轮胎规格 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "后轮胎规格"	)
				{
					后轮胎规格 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "电动天窗")
				{
					电动天窗 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "全景天窗")
				{
					全景天窗 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "运动外观套件")
				{
					运动外观套件 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "铝合金轮圈")
				{
					铝合金轮圈 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "电动吸合门")
				{
					电动吸合门 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "侧滑门")
				{
					侧滑门 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "电动后备厢")
				{
					电动后备厢 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "感应后备厢")
				{
					感应后备厢 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "车顶行李架")
				{
					车顶行李架 = iLoop;
					break;
				}
			}
			for (int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				if (RowName[iLoop - 1] == "外观颜色")
				{
					外观颜色 = iLoop;
					break;
				}
			}
		}
	}
}
