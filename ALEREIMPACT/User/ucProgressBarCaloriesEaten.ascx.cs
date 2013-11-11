using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALEREIMPACT.User
{
    public partial class ucProgressBarCaloriesEaten : System.Web.UI.UserControl
    {

        private System.Drawing.Color _colFillColor;
        private System.Drawing.Color _colBackcolor;
                                              
        private System.Drawing.Color _colBorderColor = System.Drawing.Color.Black;
        private int _intBorder = 1;
        private int _intCellspacing = 1;
        private int _intCellpadding = 1;
        private int _intHeight = 15;
                                 
        private int _intWidth = 100;
        private decimal _intBlockNumber = 0;
        private int _intValue;

        private TableRow _tblBlock;
        public System.Drawing.Color BGColor
        {
            get { return _colBackcolor; }
            set { _colBackcolor = value; }
        }
        public System.Drawing.Color FillColor
        {
            get { return _colFillColor; }
            set { _colFillColor = value; }
        }                  
        public System.Drawing.Color BorderColor
        {
            get { return _colBorderColor; }
            set { _colBorderColor = value; }
        }
        public int BorderSize
        {
            get { return _intBorder; }
            set { _intBorder = value; }
        }
        public int Cellpadding
        {
            get { return _intCellpadding; }
            set { _intCellpadding = value; }
        }
        public int CellSpacing
        {
            get { return _intCellspacing; }
            set { _intCellspacing = value; }
        }
        public decimal Blocks
        {
            get { return _intBlockNumber; }
            set { _intBlockNumber = value; }
        }

        public int Value
        {
            get { return _intValue; }
            set { _intValue = value; }
        }
        public int Height      
        {
            get { return _intHeight; }
            set { _intHeight = value; }
        }
        public int Width
        {
            get { return _intWidth; }
            set { _intWidth = value; }
        }
        protected void Page_PreRender(object sender, System.EventArgs e)
        {
            if (Session["ProgressBarPercentage"] != null)
            {
                // add a new row to the table
                _tblBlock = new TableRow();
                // create cells and add to the row
                decimal K = Convert.ToDecimal(Session["ProgressBarPercentage"]);

                //K = 100 - K;

                decimal checkAppx = 0;

                if (K == 0)
                    checkAppx = 25;

                else if (K == 10)
                    checkAppx = 1;

                else if (K >= 0 && K <= 9)
                    checkAppx = 21;

                else if (K >= 11 && K <= 19)
                    checkAppx = 20;

                else if (K <= 20)
                    checkAppx = 2;

                else if (K <= 30)
                    checkAppx = 3;

                else if (K <= 40)
                    checkAppx = 4;

                else if (K >= 41 && K <= 49)
                    checkAppx = 19;

                else if (K <= 50)
                    checkAppx = 5;

                else if (K >= 51 && K <= 59)
                    checkAppx = 16;


                else if (K <= 60)
                    checkAppx = 6;

                else if (K >= 61 && K <= 64)
                    checkAppx = 15;

                else if (K >= 65 && K <= 70)
                    checkAppx = 13;

                else if (K >= 70 && K <= 79)
                    checkAppx = 14;

                else if (K <= 80)
                    checkAppx = 8;

                else if (K >= 81 && K <= 95)
                    checkAppx = 11;

                else if (K >= 96 && K <= 99)
                    checkAppx = 12;


                else if (K >= 100)
                    checkAppx = 10;


                _tblBlock = new TableRow();

                _tblBlock = new TableRow();
                // create cells and add to the row
                int iCount = 0;
                TableCell tblCell1 = new TableCell();
                for (iCount = 1; iCount <= checkAppx; iCount++)
                {
                    TableCell tblCell = new TableCell();
                    tblCell.Text = " ";


                    /*
                   *   if 100 %
                   * */
                    if (checkAppx == 10 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("100px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }

                    /*
                   *   if > 96 but < 99 %
                   * */
                    if (checkAppx == 12 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("98px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 12 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("2px");
                        _tblBlock.Cells.Add(tblCell);
                    }

                    /*
                     *   if > 51 but < 49 %
                    * */
                    if (checkAppx == 19 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("44px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 19 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("56px");
                        _tblBlock.Cells.Add(tblCell);
                    }




                    /*
                    *   if > 1 but < 9 %
                   * */
                    if (checkAppx == 21 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("5px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 21 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("95px");
                        _tblBlock.Cells.Add(tblCell);
                    }


                    /*
                      *   if > 11 but < 19 %
                     * */
                    if (checkAppx == 20 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("12px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 20 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("88px");
                        _tblBlock.Cells.Add(tblCell);
                    }


                    /*
                   *   if > 51 but < 59 %
                   * */
                    if (checkAppx == 16 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("52px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 16 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("48px");
                        _tblBlock.Cells.Add(tblCell);
                    }


                    /*
                     *   if > 61 but < 64 %
                     * */
                    if (checkAppx == 15 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("62px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 15 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("38px");
                        _tblBlock.Cells.Add(tblCell);
                    }

                    /*
                     *   if > 65 but < 70 %
                     * */
                    if (checkAppx == 13 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("65px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 13 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("35px");
                        _tblBlock.Cells.Add(tblCell);
                    }



                    /*
                      *   if > 70 but < 79 %
                      * */
                    if (checkAppx == 14 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("70px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 14 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("30px");
                        _tblBlock.Cells.Add(tblCell);
                    }

                    /*
                    *   if > 80 but < 95 %
                    * */
                    if (checkAppx == 11 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("90px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 11 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("10px");
                        _tblBlock.Cells.Add(tblCell);
                    }


                    /*
                     *   if 80 %
                     * */
                    if (checkAppx == 8 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("80px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 8 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("20px");
                        _tblBlock.Cells.Add(tblCell);
                    }


                    /*
                    *   if < 60 %
                    * */
                    if (checkAppx == 6 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("60px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 6 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("40px");
                        _tblBlock.Cells.Add(tblCell);
                    }
                    /*
                    *   if 50 %
                    * */
                    if (checkAppx == 5 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("100px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 5 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("100px");
                        _tblBlock.Cells.Add(tblCell);
                    }

                    /*
                    *   if 40 %
                    * */
                    else if (checkAppx == 4 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("40px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 4 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("60px");
                        _tblBlock.Cells.Add(tblCell);
                    }


                    else if (checkAppx == 3 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("30px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 3 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("70px");
                        _tblBlock.Cells.Add(tblCell);
                    }



                    else if (checkAppx == 2 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("20px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }
                    else if (checkAppx == 2 && (iCount == 2))
                    {
                        tblCell.Width = new Unit("80px");
                        _tblBlock.Cells.Add(tblCell);
                    }


                    else if (checkAppx == 1 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("10px");
                        tblCell.BackColor = this.FillColor;
                        _tblBlock.Cells.Add(tblCell);
                    }

                    else if (checkAppx == 25 && (iCount == 1))
                    {
                        tblCell.Width = new Unit("0px");
                        _tblBlock.Cells.Add(tblCell);
                    }


                }
                if (checkAppx == 1)
                {
                    tblCell1.Width = new Unit("90px");
                    _tblBlock.Cells.Add(tblCell1);
                }
                if (checkAppx == 25)
                {
                    tblCell1.Width = new Unit("100px");
                    _tblBlock.Cells.Add(tblCell1);
                }
                tblProgressBar.Rows.Add(_tblBlock);

                //set the progress bar properties
                tblProgressBar.CellPadding = this.Cellpadding;
                tblProgressBar.CellSpacing = this.CellSpacing;
                tblProgressBar.Width = this.Width;
                tblProgressBar.Height = this.Height;
                tblProgressBar.BackColor = this.BGColor;
                tblProgressBar.BorderColor = this.BorderColor;
            }
        }
        public ucProgressBarCaloriesEaten()
        {
            PreRender += Page_PreRender;
        }
    }
}