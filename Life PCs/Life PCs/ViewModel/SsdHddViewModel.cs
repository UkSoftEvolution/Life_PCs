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
        private double allTotalOccupiedSpace; //Всего занято памяти
        private double allTotalSize; //Всего памяти
        private int allPercent; //Проценты занятой памяти
        #endregion

        #region Constructors
        /// <summary>
        /// Стандартный конструктор для инициализации данных
        /// </summary>
        public SsdHddViewModel()
        {
            phisical = new Phisical();
            var DiskInfo = phisical.Refresh();
            Disks = new ObservableCollection<Disk>(DiskInfo.Item1);
            AllTotalOccupiedSpace = DiskInfo.Item2;
            AllTotalSize = DiskInfo.Item3;
            AllPercent = DiskInfo.Item4;
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
        /// <summary>
        /// Всего занято памяти
        /// </summary>
        public double AllTotalOccupiedSpace
        {
            get => allTotalOccupiedSpace;
            set
            {
                allTotalOccupiedSpace = value;
                OnPropertyChanged(nameof(allTotalOccupiedSpace));
            }
        }
        /// <summary>
        /// Всего памяти
        /// </summary>
        public double AllTotalSize
        {
            get => allTotalSize;
            set
            {
                allTotalSize = value;
                OnPropertyChanged(nameof(allTotalSize));
            }
        }
        /// <summary>
        /// Проценты занятой памяти
        /// </summary>
        public int AllPercent
        {
            get => allPercent;
            set
            {
                allPercent = value;
                OnPropertyChanged(nameof(allPercent));
            }
        }
        #endregion
    }
}