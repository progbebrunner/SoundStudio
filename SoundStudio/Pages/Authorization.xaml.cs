﻿using SoundStudio.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SoundStudio.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user_log = App.Context.Users.Where(u => u.login == txtLogin.Text.Trim()).ToList();

                if (user_log.Count == 1)
                {
                    if (user_log[0].password.ToString() == txtPsw.Password.ToString())
                    {

                        var currentUser = App.Context.Users.Where(u => u.login == txtLogin.Text).FirstOrDefault();
                        App.CurrentUser = currentUser;
                        if (user_log[0].role == 2)
                        {
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                        }
                        else
                        {
                            if (user_log[0].role.ToString().Trim() == "")
                            {
                                GuestWindow gWindow = new GuestWindow(1);
                                gWindow.Show();
                            }
                            else
                            {
                                GuestWindow gWindow = new GuestWindow(1);
                                gWindow.Show();
                            }
                        }
                        Window.GetWindow(this).Close();
                    }
                    else
                    {
                        txtError.Text = "Неправильный пароль. Попробуйте снова.";
                    }
                }
                else
                {
                    txtError.Text = "Неправильный логин. Попробуйте снова.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtError.Text = "";
        }

        private void txtPsw_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtError.Text = "";
        }
    }
}
