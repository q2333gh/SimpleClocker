using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClocker {

  public partial class Form1 : Form {

    // 声明一个定时器对象
    private readonly Timer timer;

    [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
    public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
    public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);
    private const int GWL_EXSTYLE = -20;
    private const int WS_EX_TOOLWINDOW = 0x00000080;

    public Form1() {
      InitializeComponent();
      //this.Opacity = 0.9;
      ControlBox = false;
      //不显示最上面最小化按钮的一行
      //FormBorderStyle = FormBorderStyle.None;
      AutoScaleMode = AutoScaleMode.Font;
      // 初始化定时器对象
      timer = new Timer();
      // 设置定时器的间隔为1000毫秒（即一秒）
      timer.Interval = 1000;
      // 设置定时器的触发事件为Tick方法
      timer.Tick += Tick;
      // 启动定时器
      timer.Start();
    }

    private void Tick(object sender, EventArgs e) {
      label3.Text = DateTime.Now.ToString("HH:mm:ss");
      label1.Text = DateTime.Now.ToString("dddd");
      label2.Text = DateTime.Now.ToString("MM/dd/yyyy");
    }

    private void Label1_Click(object sender, EventArgs e) {

    }


    private void Form1_Load_1(object sender, EventArgs e) {
      ShowInTaskbar=false;
      //获取窗体的扩展样式
      int exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
      //添加WS_EX_TOOLWINDOW属性
      exStyle |= WS_EX_TOOLWINDOW;
      //设置窗体的扩展样式
      SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle);
      TopMost = true;
    }

    private void Label3_Click(object sender, EventArgs e) {

    }

    private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
      //判断窗体是否可见
      if (this.Visible == false) {
        //如果不可见，就显示窗体
        this.Visible = true;
        //还原窗体
        this.WindowState = FormWindowState.Normal;
      } else {
        //如果可见，就隐藏窗体
        this.Visible = false;
      }
    }
  }

}
