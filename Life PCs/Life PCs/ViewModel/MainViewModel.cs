using Life_PCs.Model;
using Life_PCs.Other;
using Life_PCs.View;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Life_PCs.ViewModel
{
    /// <summary>
    /// ViewModel: Класс для Binding с MainView
    /// </summary>
    public class MainViewModel : MVVM
    {
        #region Fields
        private ObservableCollection<PageModel> pages; //Коллекция страниц для главного меню
        private Page pageActive; //Активная страница
        private PageModel model; //Активная модель
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор для инициализации данных
        /// </summary>
        public MainViewModel()
        {
            Pages = new ObservableCollection<PageModel>
            {
                new PageModel() { PageUri = new CpuView() { DataContext = new CpuViewModel() }, PageName = "CPU", Enabled = true },
                new PageModel() { PageName = "RAM", Enabled = true },
                new PageModel() { PageName = "SSD/HDD", Enabled = true },
                new PageModel() { PageName = "Батарея", Enabled = true },
                new PageModel() { PageName = "Другое", Enabled = true }
            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Коллекция страниц для главного меню
        /// </summary>
        public ObservableCollection<PageModel> Pages
        {
            get => pages;
            set
            {
                pages = value;
                OnPropertyChanged(nameof(pages));
            }
        }
        /// <summary>
        /// Активная страница
        /// </summary>
        public Page PageActive
        {
            get => pageActive;
            set
            {
                pageActive = value;
                OnPropertyChanged(nameof(pageActive));
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Команда переключения страниц
        /// </summary>
        public RelayCommand Menu_Click => new RelayCommand(obj =>
        {
            if (model != null)
                model.Enabled = true;

            PageActive = (obj as PageModel).PageUri;
            (obj as PageModel).Enabled = false;
            model = (obj as PageModel);
        });
        #endregion
    }
}