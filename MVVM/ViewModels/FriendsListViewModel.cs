using MVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MVVM.ViewModels
{
    public class FriendsListViewModel : INotifyPropertyChanged
    {
        public PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateFriendCommand { protected set; get; }
        public ICommand DeleteFriendCommand { protected set; get; }
        public ICommand SaveFriendCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        FriendViewModel selectedFriend;
        public INavigation Navigation { get; set; }
        public FriendsListViewModel()
        {
            Friends = new ObservableCollection<FriendViewModel>();
            CreateFriendCommand = new Command(CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            BackCommand = new Command(BackCommand);
        }
        public FriendViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                if (selectedFriend != null)
                {
                    FriendViewModel tempFriend = value;
                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new FriendPage(tempFriend));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateFriend()
        {
            Navigation.PushAsync(new FriendPage(new FriendViewModel())
        }
    }
}
