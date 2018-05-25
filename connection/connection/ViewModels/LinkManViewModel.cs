using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace connection.ViewModels
{
    class LinkManViewModel
    {
        private ObservableCollection<Models.LinkMan> allItems = new ObservableCollection<Models.LinkMan>();
        public ObservableCollection<Models.LinkMan> AllItems { get { return this.allItems; } }

        private Models.LinkMan selectedItem = default(Models.LinkMan);
        public Models.LinkMan SelectedItem { get { return selectedItem; } set { this.selectedItem = value; } }

        int count = 0;
        private static LinkManViewModel instance;
        public static LinkManViewModel getinstance()
        {
            if (instance == null)
            {
                instance = new LinkManViewModel();
            }
            return instance;
        }

        public LinkManViewModel()
        {
            this.allItems.Add(new Models.LinkMan(1, "Ming", "110", "110", DateTime.Today, "SYSU", null, null));
            count++;
        }

        public int get_count()
        {
            return count;
        }

        public void AddLinkMan(long id, string name, string tel, string email, DateTime birthday, string address, BitmapImage picture, string music)
        {
            this.allItems.Add(new Models.LinkMan(id, name, tel, email, birthday, address, picture, music));
            count++;
        }

        public void RemoveLinkMan(long id)
        {
            int i = 0;
            for (i = 0; i < count; i++)
            {
                if (allItems[i].get_id() == id)
                    break;
            }
            this.allItems.Remove(allItems[i]);
            count--;
            this.selectedItem = null;
        }

        public void UpdateLinkMan(long id, string name, string tel, string email, DateTime birthday, string address, BitmapImage picture, string music)
        {
            int i = 0;
            for (i = 0; i < count; i++)
            {
                if (allItems[i].get_id() == id)
                {
                    allItems[i].rewrite_name(name);
                    allItems[i].rewrite_tel(tel);
                    allItems[i].rewrite_email(email);
                    allItems[i].rewrite_birthday(birthday);
                    allItems[i].rewrite_address(address);
                    allItems[i].rewrite_pic(picture);
                    allItems[i].rewrite_music(music);
                }
            }
            this.selectedItem = null;
        }

    }
}
