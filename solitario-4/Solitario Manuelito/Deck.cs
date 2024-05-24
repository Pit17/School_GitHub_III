using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Solitario_Manuelito
{
    class Carta
    {
        public string Name = "";
        public string Seme = "";
        public int Valore = 0;
        public Canvas canvas;

        public Carta(string card)
        {
            Carta[,] matrice = new Carta[3, 4];
            this.canvas = new Canvas();
            canvas.Width = 100;
            canvas.Height = 150;
            this.Name = card.ToString();
            canvas.Background = new ImageBrush(new BitmapImage(new Uri(@$"..\..\..\MARTINA-GRAFFIETI-CARTE-ITT-anonimo/{card}.jpg", UriKind.RelativeOrAbsolute)));
            AssegnaSeme();
            AssegnaValore();
        }

        public string AssegnaSeme()
        {
            //Tastiere,A
            //Mouse,B
            //Usb,C
            //Cuffie,D
            string seme = "";
            if (Name.Contains('A'))
            {

                seme = "Tastiere";

            }
            else if (Name.Contains('B'))
            {
                seme = "Mouse";
            }
            else if (Name.Contains('C'))
            {
                seme = "Usb";
            }
            else if (Name.Contains('D'))
            {
                seme = "Cuffie";
            }

            return seme;
        }

        public int AssegnaValore()
        {
            
            int valore=0;
            if (Name.Contains("10"))
            {
                valore = 10;
            }
            else if (Name.Contains("9"))
            {
                valore = 9;
            }
            else if (Name.Contains("8"))
            {
                valore = 8;
            }
            else if (Name.Contains("7"))
            {
                valore = 7;
            }
            else if (Name.Contains("6"))
            {
                valore = 6;
            }
            else if (Name.Contains("5"))
            {
                valore = 5;
            }
            else if (Name.Contains("4"))
            {
                valore = 4;
            }
            else if (Name.Contains("3"))
            {
                valore = 3;
            }
            else if (Name.Contains("2"))
            {
                valore = 2;
            }
            else if (Name.Contains("1"))
            {
                valore = 1;
            }
            return valore;
        }
        public void RiempiMatrice(Carta [,] matrice)
        {
            for (int i = 0;i < matrice.GetLength(0);i++)
            {
                for (int j = 0;j < matrice.GetLength(1); j++)
                {
                    if (i == 0)//scala
                    {
                        //matrice[i, j] = ;
                    }
                    else if (i == 1 && j == 0)//mazzo
                    {
                        //matrice[i, j] = ;
                    }
                    else if(i == 1 && j == 1)//trash_stack_1
                    {
                        //matrice[i, j] = ;
                    }
                    else if(i == 1 && j == 2)//trash_stack_2
                    {
                        //matrice[i, j] = ;
                    }
                    else if(i == 1 && j == 3)//trash_stack_3
                    {
                        //matrice[i, j] = ;
                    }
                    else if (i == 2)//slot inferiori
                    {
                        //matrice[i, j] = ;
                    }
                }
            }
        }
    }
}
