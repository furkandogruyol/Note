using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListToDoo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_OnCurrentPageChanged(object sender, EventArgs e)
        {
            this.Title = this.CurrentPage.Title;
        }

        protected Stack<Page> TabStack { get; set; } = new Stack<Page>();

        protected override void OnCurrentPageChanged()
        {

            // Get the current page
            var page = CurrentPage;
            if (page != null)
            {
                // Push the page onto the stack
                TabStack.Push(page);
            }

            base.OnCurrentPageChanged();
        }

        protected override bool OnBackButtonPressed()
        {

            // Go to previous page in the stack. First, pop off the top page since this represents the
            // current page we are on.
            if (TabStack.Any())
            {
                TabStack.Pop();
            }

            // See if we have any pages left
            if (TabStack.Any())
            {
                // Pop off the next page and show it
                CurrentPage = TabStack.Pop();
                // Return true to indicate we handled this
                return true;
            }

            // We don't have any more pages in the stack so do default
            return base.OnBackButtonPressed();
        }
    }
}
