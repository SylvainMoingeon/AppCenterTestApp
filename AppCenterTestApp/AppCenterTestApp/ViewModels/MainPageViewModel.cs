using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCenterTestApp.ViewModels
{
    public class MainPageViewModel : SimpleObservableObject
    {
        public String Title => "Bienvenue sur Xamarin.Forms !";

        private int number;

        public int Number
        {
            get { return number; }
            set { Set(ref number, value);
                RefreshCanExecutes();
            }
        }


        public ICommand PlusCommand { private set; get; }

        public MainPageViewModel()
        {
            PlusCommand = new Command(
                execute: () =>
                {
                    Number++;
                },
                canExecute: () =>
        {
            return Number < 10;
        });
        }



        void RefreshCanExecutes()
        {
            (PlusCommand as Command).ChangeCanExecute();

        }
    }
}
