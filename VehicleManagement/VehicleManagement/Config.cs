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
			for(int iLoop = 1; iLoop <= MaxRowNum; ++iLoop)
			{
				汽车ID = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (汽车ID);
				车型 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (车型);
				厂商 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (厂商);
				级别 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (级别);
				车身结构 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (车身结构);
				长 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (长);
				宽 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (宽);
				高 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (高);
				最高车速 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (最高车速);
				百公里加速 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (百公里加速);
				综合油耗 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (综合油耗);
				最小离地间隙 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (最小离地间隙);
				轴距 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (轴距);
				前轮距 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (前轮距);
				后轮距 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (后轮距);
				整备质量 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (整备质量);
				车门数 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (车门数);
				座位数 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (座位数);
				行李厢容积 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (行李厢容积);
				排量 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (排量);
				前轮胎规格 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (前轮胎规格);
				后轮胎规格 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (后轮胎规格);
				电动天窗 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (电动天窗);
				全景天窗 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (全景天窗);
				运动外观套件 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (运动外观套件);
				铝合金轮圈 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (铝合金轮圈);
				电动吸合门 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (电动吸合门);
				侧滑门 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (侧滑门);
				电动后备厢 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (电动后备厢);
				感应后备厢 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (感应后备厢);
				车顶行李架 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (车顶行李架);
				外观颜色 = ((string)excelcmd.GetCell(iLoop, 1) == "") ? (iLoop) : (外观颜色);
			}
		}

	}
}
