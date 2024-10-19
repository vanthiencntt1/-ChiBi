using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;


namespace Chibi
{


    public partial class Form1 : Form
    {

        private int dx = 3; // Bước di chuyển theo X
        private int dy = 3; // Bước di chuyển theo Y
        private List<Image> images; // Danh sách hình ảnh chibi
        private List<Image> imagesHinata;
        private int currentImageIndex = 0; // Chỉ số hình ảnh hiện tại
        private PictureBox pictureBox;
        private Random random;

        private int dx2 = 5; // Bước di chuyển theo X cho hình thứ 2
        private int dy2 = 5; // Bước di chuyển theo Y cho hình thứ 2
        private int currentImageIndex2 = 10; // Chỉ số hình ảnh hiện tại cho hình thứ 2
        private PictureBox pictureBox2; // PictureBox thứ 2
        public Form1()
        {
            InitializeComponent();
            // Cài đặt cửa sổ
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.Black;  //Color.Transparent; // Màu nền để làm trong suốt
             this.TransparencyKey = System.Drawing.Color.Black;  //Color.Transparent; // Màu này sẽ trở thành trong suốt

            //Color desktopColor = GetDesktopColor();

            //// Cài đặt màu nền cho form
            //this.BackColor = desktopColor;
            //this.TransparencyKey = desktopColor;

            // Sét vị trí màng  hình 
            // this.Size = new Size(500,400); // Kích thước cửa sổ (400x300 pixel)

            // this.WindowState = FormWindowState.Maximized; // Mở ở chế độ toàn màn hình
            this.Width = 400;  // Chiều dài
            this.Height = 100;   // Độ cao

            // Đặt vị trí của Form ở góc trái
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.TopMost = true; // Đảm bảo Form luôn ở trên cùng

            pictureBox_Naruto();
            pictureBox_Hinata();

            this.ShowInTaskbar = false; // Không hiện trên Taskbar
            this.TopMost = true; // Luôn nằm trên các cửa sổ khác

          
        }

        #region Naruto
        private void pictureBox_Naruto()
        {
            images = new List<Image>(); 
            for (int i = 0; i <= 166; i++)
            {
                // Tạo tên tài nguyên theo cú pháp Asset_0, Asset_1,..., Asset_170
                string assetName = $"{i}_Asset";

                // Lấy tài nguyên từ Properties.Resources bằng tên động
                Image image = (Image)Properties.Resources.ResourceManager.GetObject(assetName);

                // Nếu tài nguyên tồn tại, thêm nó vào danh sách
                if (image != null)
                {
                   
                    images.Add(image);
                }
                else
                {
                    // Xử lý nếu không tìm thấy hình ảnh trong Resources
                    Console.WriteLine($"Hình ảnh {assetName} không tồn tại trong Resources.");
                }
            }
            // Thiết lập PictureBox
            pictureBox = new PictureBox();
            pictureBox.Image = images[currentImageIndex]; // Hình ảnh đầu tiên
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(70, 50); // Kích thước của PictureBox
            pictureBox.BackColor = Color.Transparent; // Thiết lập PictureBox trong suốt
            this.Controls.Add(pictureBox);

            // Khởi tạo Random
            random = new Random();
            SetRandomMovement_Naruto(); // Thiết lập di chuyển ngẫu nhiên

            // Timer để điều khiển di chuyển
            Timer timer = new Timer();
            timer.Interval = 200; // Khoảng thời gian giữa các lần tick
            timer.Tick += Timer_Tick_Naruto;
            timer.Start();
        }
        private void Timer_Tick_Naruto(object sender, EventArgs e)
        {
            // Cập nhật vị trí PictureBox
            pictureBox.Left += dx;
            pictureBox.Top += dy;

            // Nếu PictureBox chạm vào biên màn hình, đổi hướng
            if (pictureBox.Left <= 0 || pictureBox.Right >= this.Width)
            {
                dx = -dx; // Đổi hướng X
            }

            if (pictureBox.Top <= 0 || pictureBox.Bottom >= this.Height)
            {
                dy = -dy; // Đổi hướng Y
            }
            // Cập nhật hình ảnh cho hiệu ứng chuyển động
            currentImageIndex++;
            if (currentImageIndex >= images.Count)
            {
                currentImageIndex = 0; // Quay về hình ảnh đầu tiên
            }
            pictureBox.Image = images[currentImageIndex]; // 
        }
        private void SetRandomMovement_Naruto()
        {
            // Thiết lập bước di chuyển ngẫu nhiên cho dx và dy
            dx = random.Next(1, 10); // Giá trị ngẫu nhiên từ 1 đến 9
            dy = random.Next(1, 10); // Giá trị ngẫu nhiên từ 1 đến 9
            if (random.Next(2) == 0) dx = -dx; // Đảo ngược dx với xác suất 50%
            if (random.Next(2) == 0) dy = -dy; // Đảo ngược dy với xác suất 50%


        }

        #endregion Naruto

        #region Hinata
        private void pictureBox_Hinata()
        {
            imagesHinata = new List<Image>();
            for (int i = 0; i <= 170; i++)
            {
                string assetName = $"Asset_{i}";

                Image image = (Image)Properties.Resources.ResourceManager.GetObject(assetName);

                // Nếu tài nguyên tồn tại, thêm nó vào danh sách
                if (image != null)
                {
                    imagesHinata.Add(image);
                }
                else
                {
                    Console.WriteLine($"Hình ảnh {assetName} không tồn tại trong Resources.");
                }
            }
            pictureBox2 = new PictureBox();
            pictureBox2.Image = imagesHinata[currentImageIndex]; // Hình ảnh đầu tiên của hình thứ 2
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Size = new Size(70, 50); // Kích thước của PictureBox thứ 2
            pictureBox2.BackColor = Color.Transparent; // Làm trong suốt PictureBox thứ 2
            this.Controls.Add(pictureBox2); // Thêm PictureBox thứ 2 vào form

            // Đặt vị trí ngẫu nhiên cho PictureBox thứ 2
            pictureBox2.Left = random.Next(this.Width - pictureBox2.Width);
            pictureBox2.Top = random.Next(this.Height - pictureBox2.Height);

            // Di chuyển ngẫu nhiên cho PictureBox thứ 2
            SetRandomMovement_hinata();

            // Timer điều khiển cả hai hình ảnh
            Timer timer = new Timer();
            timer.Interval = 200; // Khoảng thời gian giữa các lần tick
            timer.Tick += Timer_Tick_hinata;
            timer.Start();


        }

        private void Timer_Tick_hinata(object sender, EventArgs e)
        {
            // Cập nhật vị trí cho PictureBox 2
            pictureBox2.Left += dx2;
            pictureBox2.Top += dy2;

            // Đổi hướng khi PictureBox 2 chạm biên
            if (pictureBox2.Left <= 0 || pictureBox2.Right >= this.Width)
            {
                dx2 = -dx2; // Đổi hướng X
              
            }

            if (pictureBox2.Top <= 0 || pictureBox2.Bottom >= this.Height)
            {
                dy2 = -dy2; // Đổi hướng Y
        
            }

            // Cập nhật hình ảnh cho hiệu ứng chuyển động của PictureBox 2
            currentImageIndex2++;
            if (currentImageIndex2 >= imagesHinata.Count)
            {
                currentImageIndex2 = 0; // Quay lại hình ảnh đầu tiên
            }
            pictureBox2.Image = imagesHinata[currentImageIndex2]; // Hình ảnh liên quan đến Hinata
        }
        private void SetRandomMovement_hinata()
        {
            // Thiết lập bước di chuyển ngẫu nhiên cho dx2 và dy2
            dx2 = random.Next(1, 10);
            dy2 = random.Next(1, 10);
            if (random.Next(2) == 0) dx2 = -dx2;
            if (random.Next(2) == 0) dy2 = -dy2;
        }
        #endregion Hinata
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Color GetDesktopColor()
        {
            // Lấy màu nền của Desktop
            return System.Drawing.SystemColors.Control; // Hoặc bạn có thể dùng màu khác như Color.FromKnownColor(KnownColor.Window)
        }

       
    }
}
