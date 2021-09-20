using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FCBHXamarinMy.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel()
        {
            SelectCategoryCommand = new Command<string>(OnSelectCategory);
        }

        int selectedCategoryIndex;
        public int SeletedCategoryIndex
        {
            get => selectedCategoryIndex;
            set => SetProperty(ref selectedCategoryIndex, value);
        }

        public Command<string> SelectCategoryCommand { get; }

        void OnSelectCategory(string index)
        {
            if(int.TryParse(index, out int i))
            {
                selectedCategoryIndex = i;
            }
        }
    }
}
