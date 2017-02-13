using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tic_Tac_Toee
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(1000, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

        }

        public int players = 2;
        public int turns = 0;
        public int s1 = 0;
        public int s2 = 0;
        public int sd = 0;

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content == "")
            {
                if (players % 2 == 0)
                {
                    button.Content = "X";
                    players++;
                    turns++;
                }
                else
                {
                    button.Content = "O";
                    players++;
                    turns++;
                }

                if (checkDraw() == true)
                {
                    sd++;
                    NewGame();
                }

                if (checkWinner()==true)
                {
                    if(button.Content=="X")
                    {
                        s1++;
                        NewGame();
                    }
                    else
                    {
                        s2++;
                        NewGame();
                    }
                }
            }
        }

        private void label_Load(object sender, RoutedEventArgs e)
        {
            Xwin.Text = "X: " + s1;
            Ywin.Text = "O: " + s2;
            Draws.Text = "Draws: " + sd;
        }

        void NewGame()
        {
            players = 2;
            turns = 0;
            A00.Content = A01.Content = A02.Content = A10.Content = A11.Content = A12.Content = A20.Content = A21.Content = A22.Content = "";
            Xwin.Text = "X: " + s1;
            Ywin.Text = "O: " + s2;
            Draws.Text = "Draws: " + sd;
        }



        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        bool checkDraw()
        {
            if (turns==9  && checkWinner()==false)
            {
                return true;
            }
            else return false;
        }

        bool checkWinner()
        {
            if ((A00.Content == A01.Content) && (A01.Content == A02.Content) && A00.Content != "") return true;
            else if ((A10.Content == A11.Content) && (A11.Content == A12.Content) && A10.Content != "") return true;
            else if ((A20.Content == A21.Content) && (A21.Content == A22.Content) && A20.Content != "") return true;

            if ((A00.Content == A10.Content) && (A10.Content == A20.Content) && A00.Content != "") return true;
            else if ((A01.Content == A11.Content) && (A11.Content == A21.Content) && A01.Content != "") return true;
            else if ((A02.Content == A12.Content) && (A12.Content == A22.Content) && A02.Content != "") return true;

            if ((A00.Content == A11.Content) && (A11.Content == A22.Content) && A00.Content != "") return true;
            else if ((A02.Content == A11.Content) && (A11.Content == A20.Content) && A02.Content != "") return true;

            else return false;
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            s1 = s2 = sd = 0;
            NewGame();
        }
    }
}
