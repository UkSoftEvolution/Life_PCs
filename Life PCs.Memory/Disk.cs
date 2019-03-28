namespace Life_PCs.Memory
{
    /// <summary>
    /// Класс для хранения информации о локальных дисках компьютера
    /// </summary>
    public class Disk
    {
        #region Fields
        private string name; //Имя
        private double totalOccupiedSpace; //Всего занято места
        private int percent; //Всего занято места в процентах
        private double totalSize; //Общий размер
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор для инициализации данных локального диска
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="TotalOccupiedSpace">Всего занято места</param>
        /// <param name="Percent">Всего занято места в процентах</param>
        /// <param name="TotalSize">Общий размер</param>
        public Disk(string Name, double TotalOccupiedSpace, int Percent, double TotalSize)
        {
            name = Name;
            totalOccupiedSpace = TotalOccupiedSpace;
            percent = Percent;
            totalSize = TotalSize;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get => name; }
        /// <summary>
        /// Всего занято места
        /// </summary>
        public double TotalOccupiedSpace { get => totalOccupiedSpace; }
        /// <summary>
        /// Всего занято места в процентах
        /// </summary>
        public int Percent { get => percent; set => percent = value; }
        /// <summary>
        /// Общий размер
        /// </summary>
        public double TotalSize { get => totalSize; set => totalSize = value; }
        #endregion
    }
}