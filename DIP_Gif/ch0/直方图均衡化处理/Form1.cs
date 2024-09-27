using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 直方图均衡化处理
{
    public partial class Form1 : Form
    {
        #region 常量，变量
        public string Picfilename;//打开路径
        public string filename;//保存路径
        public Bitmap bitmap;
        public Bitmap newbitmap;
        #endregion

        #region Form1
        public Form1()
        {
            InitializeComponent();
        } 
        #endregion

        #region 窗体加载事件
                private void Form1_Load(object sender, EventArgs e)
        {
            changeSizeMode();
        }
        #endregion

        #region 转换图片显示模式
                                public void changeSizeMode()
                {
                    if (pictureBox2.SizeMode == PictureBoxSizeMode.AutoSize)
                        pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }
                #endregion


        #region 获取图像并设置全局bitmap
        //获取图像并设置全局bitmap
        private void button1_Click(object sender, EventArgs e)
        {
            changeSizeMode();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                Picfilename = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(Picfilename);
            bitmap =(Bitmap) pictureBox1.Image;
        }
        #endregion

        #region 直方图均衡化处理
                //直方图均衡化处理
        private void button2_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                newbitmap = bitmap.Clone() as Bitmap; //clone一个副本
                int width = newbitmap.Width;
                int height = newbitmap.Height;
                int size = width*height;
                //总像数个数
                int[] gray = new int[256];
                //定义一个int数组，用来存放各像元值的个数
                double[] graydense = new double[256];
                //定义一个float数组，存放每个灰度像素个数占比
                for (int i = 0; i < width; ++i)
                    for (int j = 0; j < height; ++j)
                    {
                        Color pixel = newbitmap.GetPixel(i, j);
                        //计算各像元值的个数
                        gray[Convert.ToInt16(pixel.R)] += 1;
                        //由于是灰度只读取R值
                    }
                for (int i = 0; i < 256; i++)
                {
                    graydense[i] = (gray[i]*1.0)/size;
                    //每个灰度像素个数占比
                }

                for (int i = 1; i < 256; i++)
                {
                    graydense[i] = graydense[i] + graydense[i - 1];
                    //累计百分比
                }

                for (int i = 0; i < width; ++i)
                    for (int j = 0; j < height; ++j)
                    {
                        Color pixel = newbitmap.GetPixel(i, j);
                        int oldpixel = Convert.ToInt16(pixel.R); //原始灰度
                        int newpixel = 0;
                        if (oldpixel == 0)
                            newpixel = 0;
                        //如果原始灰度值为0则变换后也为0
                        else
                            newpixel = Convert.ToInt16(graydense[Convert.ToInt16(pixel.R)]*255);
                        //如果原始灰度不为0，则执行变换公式为   <新像元灰度 = 原始灰度 * 累计百分比>
                        pixel = Color.FromArgb(newpixel, newpixel, newpixel);
                        newbitmap.SetPixel(i, j, pixel); //读入newbitmap
                    }
                pictureBox2.Image = newbitmap.Clone() as Image; //显示至pictureBox2

            }
        }
        #endregion

        #region 灰度图
                //灰度图
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap Abitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    //灰度加权平均法公式
                    int rgb = (int)(c.R * 0.299 + c.G * 0.587 + c.B * 0.114);
                    Abitmap.SetPixel(i, j, Color.FromArgb(rgb, rgb, rgb));
                }
            }
            pictureBox3.Image = Abitmap.Clone() as Image;
        }
        #endregion

        #region 图像卷积与滤波——高斯平滑
        
        private double[,] GaussianBlur;//声明私有的高斯模糊卷积核函数
 
        /// <summary>
        /// 构造卷积（Convolution）类函数
        /// </summary>
        public void Convolution()
        {
            //初始化高斯模糊卷积核
            int k=273;
            GaussianBlur = new double[5, 5]{{(double)1/k,(double)4/k,(double)7/k,(double)4/k,(double)1/k},
                                            {(double)4/k,(double)16/k,(double)26/k,(double)16/k,(double)4/k},
                                            {(double)7/k,(double)26/k,(double)41/k,(double)26/k,(double)7/k},
                                            {(double)4/k,(double)16/k,(double)26/k,(double)16/k,(double)4/k},
                                            {(double)1/k,(double)4/k,(double)7/k,(double)4/k,(double)1/k}};
        }

        /// <summary>
        /// 对图像进行平滑处理（利用高斯平滑Gaussian Blur）
        /// </summary>
        /// <param name="bitmap">要处理的位图</param>
        /// <returns>返回平滑处理后的位图</returns>
        public Bitmap Smooth(Bitmap bitmap) 
        {
            int[, ,] InputPicture = new int[3, bitmap.Width, bitmap.Height];//以RGB以及位图的长宽建立整数输入的位图的数组
 
            Color color = new Color();//储存某一像素的颜色
            //循环使得InputPicture数组得到位图的RGB
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    InputPicture[0, i, j] = color.R;
                    InputPicture[1, i, j] = color.G;
                    InputPicture[2, i, j] = color.B;
                }
            }
 
            int[, ,] OutputPicture = new int[3, bitmap.Width, bitmap.Height];//以GRB以及位图的长宽建立整数输出的位图的数组
            Bitmap smooth = new Bitmap(bitmap.Width, bitmap.Height);//创建新位图
            //循环计算使得OutputPicture数组得到计算后位图的RGB
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int R=0;
                    int G=0;
                    int B=0;
 
                    //每一个像素计算使用高斯模糊卷积核进行计算
                    for (int r = 0; r < 5; r++)//循环卷积核的每一行
                    {
                        for (int f = 0; f < 5; f++)//循环卷积核的每一列
                        {
                            //控制与卷积核相乘的元素
                            int row = i - 2 + r;
                            int index = j - 2 + f;
                            
                            //当超出位图的大小范围时，选择最边缘的像素值作为该点的像素值
                            row = row < 0 ? 0 : row;
                            index = index < 0 ? 0 : index;
                            row = row >= bitmap.Width ? bitmap.Width - 1 : row;
                            index = index >= bitmap.Height ? bitmap.Height - 1 : index;
 
                            //输出得到像素的RGB值
                            R += (int)(GaussianBlur[r, f] * InputPicture[0, row, index]);
                            G += (int)(GaussianBlur[r, f] * InputPicture[1, row, index]);
                            B += (int)(GaussianBlur[r, f] * InputPicture[2, row, index]);
                        }
                    }
                    color = Color.FromArgb(R,G,B);//颜色结构储存该点RGB
                    smooth.SetPixel(i, j, color);//位图存储该点像素值
                }
            }
            return smooth;
        }        
        //平滑处理按钮
        private void button4_Click(object sender, EventArgs e)
        {
            Convolution();
            pictureBox2.Image = Smooth(bitmap);
        }
        #endregion

        #region 柔化处理
        private void btn_rouhua_Click(object sender, EventArgs e)
        {
            //以柔化效果显示图像

            try
            {
                int Height = bitmap.Height;
                int Width = bitmap.Width;
                Bitmap newbitmap = new Bitmap(Width, Height);
                Color pixel;
                //高斯模板
                int[] Gauss = { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
                for (int x = 1; x < Width - 1; x++)
                    for (int y = 1; y < Height - 1; y++)
                    {
                        int r = 0, g = 0, b = 0;
                        int Index = 0;
                        for (int col = -1; col <= 1; col++)
                            for (int row = -1; row <= 1; row++)
                            {
                                pixel = bitmap.GetPixel(x + row, y + col);
                                r += pixel.R * Gauss[Index];
                                g += pixel.G * Gauss[Index];
                                b += pixel.B * Gauss[Index];
                                Index++;
                            }
                        r /= 16;
                        g /= 16;
                        b /= 16;
                        //处理颜色值溢出
                        r = r > 255 ? 255 : r;
                        r = r < 0 ? 0 : r;
                        g = g > 255 ? 255 : g;
                        g = g < 0 ? 0 : g;
                        b = b > 255 ? 255 : b;
                        b = b < 0 ? 0 : b;
                        newbitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
                    }
                this.pictureBox2.Image = newbitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }
        #endregion

        #region 锐化处理
                private void btn_jianrui_Click(object sender, EventArgs e)
        {
            //以锐化效果显示图像
            try
            {
                int Height = bitmap.Height;
                int Width = bitmap.Width;
                Bitmap newBitmap = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel;
                //拉普拉斯模板
                int[] Laplacian = { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
                for (int x = 1; x < Width - 1; x++)
                    for (int y = 1; y < Height - 1; y++)
                    {
                        int r = 0, g = 0, b = 0;
                        int Index = 0;
                        for (int col = -1; col <= 1; col++)
                            for (int row = -1; row <= 1; row++)
                            {
                                pixel = oldBitmap.GetPixel(x + row, y + col); 
                                r += pixel.R * Laplacian[Index];
                                g += pixel.G * Laplacian[Index];
                                b += pixel.B * Laplacian[Index];
                                Index++;
                            }
                        //处理颜色值溢出
                        r = r > 255 ? 255 : r;
                        r = r < 0 ? 0 : r;
                        g = g > 255 ? 255 : g;
                        g = g < 0 ? 0 : g;
                        b = b > 255 ? 255 : b;
                        b = b < 0 ? 0 : b;
                        newBitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
                    }
                this.pictureBox2.Image = newBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }

        }
        #endregion

        #region 保存图像
        private void btn_save_Click(object sender, EventArgs e)
{
    //保存图片
    //保存图片函数 Image.Save(filename, imgformat); 
    //imgformat保存文件类型，filename保存文件路径
    bool isSave = true;//判断是否保存
    if (saveFileDialog1.ShowDialog() == DialogResult.OK)//判断保存路径是否正确
    {
        filename = saveFileDialog1.FileName.ToString();//存放保存路径
        if (filename != "" && filename != null)
        {
            string fileExtName = filename.Substring(filename.LastIndexOf(".") + 1).ToString();//保存文件后缀名
            System.Drawing.Imaging.ImageFormat imgformat = null;
            if (filename != " ")
            {
                switch (fileExtName)
                {
                    case "jpg":
                        imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;//保存文件类型

                        break;
                    case "bmp":
                        imgformat = System.Drawing.Imaging.ImageFormat.Bmp;

                        break;
                    case "gif":
                        imgformat = System.Drawing.Imaging.ImageFormat.Gif;

                        break;
                    default:
                        MessageBox.Show("只能存取为：jpg,bmp,gif格式");
                        isSave = false;
                        break;
                }
            }
            //默认保存为JPG
            if (imgformat == null)
            {
                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
            }
            if (isSave)
            {
                switch (comboBox1.SelectedIndex)
                { 
                    case 0:
                        try
                        {
                            pictureBox1.Image.Save(filename, imgformat);
                            MessageBox.Show("图片已经成功保存！");
                            pictureBox1.Image = Image.FromFile(filename); //picturebox2显示图片
                        }
                        catch
                        {
                            MessageBox.Show("保存失败，你已经清空图片！");
                        }
                        break;
                    case 1:
                        try
                        {
                            pictureBox2.Image.Save(filename, imgformat);
                            MessageBox.Show("图片已经成功保存！");
                            pictureBox2.Image = Image.FromFile(filename); //picturebox2显示图片
                        }
                        catch
                        {
                            MessageBox.Show("保存失败，你已经清空图片！");
                        }
                        break;
                    case 2:
                        try
                        {
                            pictureBox3.Image.Save(filename, imgformat);
                            MessageBox.Show("图片已经成功保存！");
                            pictureBox3.Image = Image.FromFile(filename); //picturebox2显示图片
                        }
                        catch
                        {
                            MessageBox.Show("保存失败，你已经清空图片！");
                        }
                        break;
                    default:
                        MessageBox.Show("保存失败,请选择正确的图片！");
                        break;

                        
                }
                        
            }
        }

    }
}
        #endregion

        #region 雾化处理
                private void btn_wuhua_Click(object sender, EventArgs e)
        {
            //以雾化效果显示图像
            try
            {
                int Height = bitmap.Height;
                int Width = bitmap.Width;
                Bitmap newBitmap = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel;
                for (int x = 1; x < Width - 1; x++)
                    for (int y = 1; y < Height - 1; y++)
                    {
                        System.Random MyRandom = new Random();
                        int k = MyRandom.Next(123456);
                        //像素块大小
                        int dx = x + k % 19;
                        int dy = y + k % 19;
                        if (dx >= Width)
                            dx = Width - 1;
                        if (dy >= Height)
                            dy = Height - 1;
                        pixel = oldBitmap.GetPixel(dx, dy);
                        newBitmap.SetPixel(x, y, pixel);
                    }
                this.pictureBox2.Image = newBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }

        }

        #endregion

        #region 底片效果显示
                                private void btn_dipian_Click(object sender, EventArgs e)
        {
            //以底片效果显示图像
            try
            {
                int Height = bitmap.Height;
                int Width = bitmap.Width;
                Bitmap newbitmap = new Bitmap(Width, Height);
                Bitmap oldbitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel;
                for (int x = 1; x < Width; x++)
                {
                    for (int y = 1; y < Height; y++)
                    {
                        int r, g, b;
                        pixel = oldbitmap.GetPixel(x, y);
                        r = 255 - pixel.R;
                        g = 255 - pixel.G;
                        b = 255 - pixel.B;
                        newbitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                this.pictureBox2.Image = newbitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

                }
                #endregion

        #region 浮雕效果显示
                                                                private void btn_fudiao_Click(object sender, EventArgs e)
        {
            //以浮雕效果显示图像
            try
            {
                int Height = bitmap.Height;
                int Width = bitmap.Width;
                Bitmap newBitmap = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel1, pixel2;
                for (int x = 0; x < Width - 1; x++)
                {
                    for (int y = 0; y < Height - 1; y++)
                    {
                        int r = 0, g = 0, b = 0;
                        pixel1 = oldBitmap.GetPixel(x, y);
                        pixel2 = oldBitmap.GetPixel(x + 1, y + 1);
                        r = Math.Abs(pixel1.R - pixel2.R + 128);
                        g = Math.Abs(pixel1.G - pixel2.G + 128);
                        b = Math.Abs(pixel1.B - pixel2.B + 128);
                        if (r > 255)
                            r = 255;
                        if (r < 0)
                            r = 0;
                        if (g > 255)
                            g = 255;
                        if (g < 0)
                            g = 0;
                        if (b > 255)
                            b = 255;
                        if (b < 0)
                            b = 0;
                        newBitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                this.pictureBox2.Image = newBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
                                #endregion

        #region 缩放
                                                                                                                private void btn_size_Click(object sender, EventArgs e)
{
    pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
    if (pictureBox2.Image == null)
    {
        pictureBox2.Image = bitmap;
    }
    double resizedth = 1;//倍数初始化为1
    resizedth = double.Parse(textBox1.Text);//从textbox获取倍数
    if (resizedth >= 1)
    {
                
        Bitmap bmp1 = (Bitmap)pictureBox2.Image;
        int picture_width = bmp1.Width;//获取图片宽度
        int picture_height = bmp1.Height;//获取图片高度
        Bitmap resizedBmp = new Bitmap((int)(picture_width * resizedth), (int)(picture_height * resizedth));//新建位图，宽高分辨率缩小
        Color present;
        for (int i = 0; i < (int)(picture_width * resizedth); i++)
            for (int j = 0; j < (int)(picture_height * resizedth); j++)
            {
                int resized_i = (int)(i / resizedth);
                int resized_j = (int)(j / resizedth);
                present = bmp1.GetPixel(resized_i, resized_j);//获取原图片像素
                resizedBmp.SetPixel(i, j, present);//设置放大后图片像素
            }
        pictureBox2.Image = resizedBmp;//放大后图片显示
    }
    else
    {

        Bitmap bmp1 = (Bitmap)pictureBox2.Image;
        int picture_width = bmp1.Width;//获取图片宽度
        int picture_height = bmp1.Height;//获取图片高度
        Bitmap resizedBmp = new Bitmap((int)(picture_width * resizedth), (int)(picture_height * resizedth));//新建位图，宽高分辨率缩小
        Color present;
        for (int i = 0; i < bmp1.Width; i++)
            for (int j = 0; j < bmp1.Height; j++)
            {
                int resized_i = (int)(i * resizedth);
                int resized_j = (int)(j * resizedth);
                present = bmp1.GetPixel(i, j);//获取原图片像素
                if (resized_i >= 0 && resized_i < (int)(picture_width * resizedth))
                    if (resized_j >= 0 && resized_j < (int)(picture_height * resizedth))//解决 缩小后图片边界数值相同时出错的问题
                        resizedBmp.SetPixel(resized_i, resized_j, present);//设置缩小后图片像素
            }
        pictureBox2.Image = resizedBmp;//缩小后图片显示
    }
}        
                                                        #endregion







        



       

                






    }
}





