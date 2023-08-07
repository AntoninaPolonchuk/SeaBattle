using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class CreateShips : Form
    {

        public int[,] gamerField;


        public CreateShips()
        {
            InitializeComponent();
            gamerField = CreateMath();
        }

        private void createShipsByClick(object sender, EventArgs e)
        {
            DrawShip((Button)sender);
        }


        public void DrawShip(Button currentButton)
        {
            string[] coordinates = currentButton.Name.ToString().Split('_');

            //int coordX = int.Parse(coords[1]);
            //int coordY = int.Parse(coords[2]);

            Point coords = new Point(int.Parse(coordinates[1]), int.Parse(coordinates[2]));

            //Point point = new Point(coordX - 1, coordY - 1);
            bool isSpipOnPlace;

            if (gamerField[coords.X, coords.Y] == 0 || gamerField[coords.X, coords.Y] ==1)
            {
                if (gamerField[coords.X, coords.Y] == 0)
                {
                    isSpipOnPlace = false;
                    gamerField[coords.X, coords.Y] = 1;
                    currentButton.BackColor = Color.Black;
                }
                else
                {
                    isSpipOnPlace = true;
                    gamerField[coords.X, coords.Y] = 0;
                    currentButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
                }

                ChangeButtonVis(coords.X - 1, coords.Y - 1, isSpipOnPlace);
                ChangeButtonVis(coords.X - 1, coords.Y + 1, isSpipOnPlace);
                ChangeButtonVis(coords.X + 1, coords.Y - 1, isSpipOnPlace);
                ChangeButtonVis(coords.X + 1, coords.Y + 1, isSpipOnPlace);

                //for (int i = 0; i < 3; i++)
                //{
                //    point.X = coordX - 1;

                //    for (int j= 0; j < 3; j++)
                //    {
                //        if (point.X != coordX && point.Y != coordY && point.X>=0 && point.Y >=0 && point.X <=9 && point.Y <=9)
                //        {
                //            ChangeButtonVis(point.X, point.Y, isSpipOnPlace);
                //        }
                //        point.X++;
                //    }
                //    point.Y++;
                //}
            }

            else if (gamerField[coords.X, coords.Y] == -1)
            {
                //вывод предупреждения о невозможности. 
            }



        }

  


        public void ChangeButtonVis(int coordX, int coordY, bool isSpipOnPlace)
        {
            string buttonName = "button_" + coordX.ToString() + "_" + coordY.ToString();

            Control currentButton = tableLayoutPanel1.Controls[buttonName] as Button;
            //Point point = new Point(coordX-1, coordY-1);
            //bool mainShipStatus = isSpipOnPlace;
            //bool currentShipStatus = false;

            if (coordX >= 0 && coordY >= 0 && coordX <= 9 && coordY <= 9)
            {
                if (isSpipOnPlace == false) 
                {
                    gamerField[coordX, coordY] = - 1;
                    currentButton.Text = "X";
                }
                else if (isSpipOnPlace == true)
                {
                    if (gamerField[coordX - 1, coordY - 1] == 1 || gamerField[coordX + 1, coordY - 1] == 1 ||
                        gamerField[coordX - 1, coordY + 1] == 1 || gamerField[coordX + 1, coordY + 1] == 1)
                    { }
                    else
                    {
                        gamerField[coordX, coordY] = 0;
                        currentButton.Text = "";
                    }
                }
            }






           

            //if (isSpipOnPlace == false) {
            //    gamerField[coordX, coordY] = -1;
            //    currentButton.Text = "X";
            //}
            //else if (isSpipOnPlace == true)
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        point.X = coordX - 1;

            //        for (int j = 0; j < 3; j++)
            //        {
            //            if (point.X != coordX && point.Y != coordY && point.X >= 0 && point.Y >= 0 && point.X <= 9 && point.Y <= 9)
            //            {
            //                if (gamerField[point.X, point.Y] == 1)
            //                {
            //                    currentButton.Text = "X";
            //                }
            //                else
            //                {
            //                    gamerField[coordX, coordY] = -1;
            //                    currentButton.Text = "";
            //                }
            //            }
            //            point.X++;
            //        }
            //        point.Y++;
            //    }
            //}
        }








        public int [,] CreateMath()
        {
            int [,] newMath = new int[10,10];
            return newMath;
            // 0 - пустота
            // 1 - корабль
            // - 1 - недоступная клетка
        }



    }
}
