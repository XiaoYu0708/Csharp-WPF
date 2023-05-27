using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Window2.xaml 的互動邏輯
    /// </summary>
    public partial class Window2 : Window
    {

        List<Course> courses = new List<Course>();
        Course? selectedCourse = null;
        public Window2()
        {
            InitializeComponent();
            InitializeCourse(courses);
        }


        private void InitializeCourse(List<Course> mycourse)
        {
            Course course1 = new Course() { Teacher = "許子衡",Class= "網路程式設計(Network Programming)", Openclass = "四技資工三甲, 四技資工三乙", Main = "中文大綱 :\r\n1 Sockets and System\r\n2.1 Operation\r\n2.2 Socket types\r\n2.3 Domains\r\n2.4 Name Binding\r\n2.5 Closing Sockets\r\n2.6 I/O Multiplexing\r\n2.7 IPC\r\n2.8 ThreadClient/Server Models\r\n3.1 UDP\r\n3.2 TCP\r\n4 Connection Based Services\r\n4.1 Client and Server actions\r\n4.2 Handling Out of Band Data\r\n4.3 FTP\r\n4.4 HTTP\r\n5 Connectionless Services\r\n5.1 Client and Server actions\r\n5.1 Data Transfer\r\n5.1 DNS\r\n英文大綱 :\r\n1 Sockets and System\r\n2.1 Operation\r\n2.2 Socket types\r\n2.3 Domains\r\n2.4 Name Binding\r\n2.5 Closing Sockets\r\n2.6 I/O Multiplexing\r\n2.7 IPC\r\n2.8 ThreadClient/Server Models\r\n3.1 UDP\r\n3.2 TCP\r\n4 Connection Based Services\r\n4.1 Client and Server actions\r\n4.2 Handling Out of Band Data\r\n4.3 FTP\r\n4.4 HTTP\r\n5 Connectionless Services\r\n5.1 Client and Server actions\r\n5.1 Data Transfer\r\n5.1 DNS" };
            courses.Add(course1);

            Course course2 = new Course() { Teacher = "陳定宏", Class = "物件導向程式設計(C)(Object-Oriented Programming)", Openclass = "四技資工一甲, 四技資工一乙, 四技資工一丙", Main = "中文大綱 :\r\n1. 物件程式語言導論\r\n2. C++ 語言的基本元素\r\n3. 基本的輸出與輸入\r\n4. 基本敘述\r\n5. 前端處理器\r\n6. 常用庫存函數\r\n7. 函數\r\n8. 陣列\r\n9. 類別\r\n10. 字串\r\n11. 例外處理\r\n12. 檔案\r\n\r\n\r\n英文大綱 :\r\n1. Introduction\r\n2. Basic C++\r\n3. Input and Output\r\n4. Statements\r\n5. Preprocessing\r\n6. Library Function\r\n7. Functions\r\n8. Arrays\r\n9. Classes\r\n10. Strings\r\n11. Exceptionn Handling\r\n12. File Processing" };
            courses.Add(course2);

            Course course3 = new Course() { Teacher = "陳福坤", Class = "機率與統計(Probability and Statistics)", Openclass = "四技資工三甲", Main = "中文大綱 :\r\n1. 統計學導論\r\n2. 資料蒐集方法\r\n3. 資料分析整理與特徵值\r\n4. 機率概念與常用機率模式\r\n5. 抽樣分配\r\n6. 參數估計\r\n7. 假說檢定\r\n英文大綱 :\r\n1. Introduction to statistic\r\n2. Data collection Methods\r\n3. Data Analysis\r\n4. Probability Models\r\n5. Sampling Distribution\r\n6. Estimation of Parameters\r\n7. Hypothesis testing" };
            courses.Add(course3);

            cmbCourse.ItemsSource = courses;
            cmbCourse.SelectedIndex = 0;
        }

        private void cmbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = (Course)cmbCourse.SelectedItem;

            tbTeacher_s.Text = selectedCourse.Teacher;
            tbOpencourse_s.Text = selectedCourse.Openclass;
            tbMain_s.Text = selectedCourse.Main;
        }
    }
}
