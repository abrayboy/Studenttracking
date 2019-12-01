using Studenttracking.IO;
using Studenttracking.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Studenttracking
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public StudentsViewModel StudentsViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.StudentsViewModel = new StudentsViewModel();
            this.DataContext = this.StudentsViewModel;
        }

        public async void readSpreadSheet()
        {
            var filePicker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };

            var spreadSheet = await filePicker.PickSingleFileAsync();

            var studentManagerBuilder = new StudentManagerBuilder();

            var studentList = await studentManagerBuilder.Build(spreadSheet);
        }
    }
}
