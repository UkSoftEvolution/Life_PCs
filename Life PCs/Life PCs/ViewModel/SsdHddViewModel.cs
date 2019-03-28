using Life_PCs.Other;
using Life_PCs.Memory;
using System.Collections.ObjectModel;

namespace Life_PCs.ViewModel
{
    /// <summary>
    /// ViewModel: Класс для Binding с SsdHddView
    /// </summary>
    public class SsdHddViewModel : MVVM
    {
        #region Fields
        private Phisical phisical; //Объект класса для работы с SSD и HDD устройствами
        private ObservableCollection<Disk> disks; //Коллекция локальных дисков
        #endregion

        #region Constructors
        /// <summary>
        /// Стандартный конструктор для инициализации данных
        /// </summary>
        public SsdHddViewModel()
        {
            phisical = new Phisical();
            Disks = new ObservableCollection<Disk>(phisical.Refresh());
        }
        #endregion

        #region
        /// <summary>
        /// Коллекция локальных дисков
        /// </summary>
        public ObservableCollection<Disk> Disks
        {
            get => disks;
            set
            {
                disks = value;
                OnPropertyChanged(nameof(disks));
            }
        }
        #endregion
    }
}