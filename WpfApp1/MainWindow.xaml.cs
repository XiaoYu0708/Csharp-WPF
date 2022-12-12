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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Teacher> teachers = new List<Teacher>();
        List<Course> courses = new List<Course>();
        public MainWindow()
        {
            InitializeComponent();

            //建立測試資料
            Teacher teacher1 = new Teacher("陳定宏");
            //Course coursela = new Course(teacher1) {CourseNmae="視窗程式設計",OpeningClass="五專三甲",Point=3,Type="必修" };
            //teacher1.TeachingCourses.Add(coursela);
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "五專三甲", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二甲", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技三乙", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技三丙", Point = 3, Type = "必修" });

            teachers.Add(teacher1);

            Teacher teacher2 = new Teacher("杜俊育");
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "行動無線通訊", OpeningClass = "碩研資工一甲等合開", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "行動電信網路應用", OpeningClass = "四技資工三甲等合開", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "雲端人工智慧運算實務", OpeningClass = "四技資工四甲等合開", Point = 3, Type = "選修" });

            teachers.Add(teacher2);

            trvteacher.ItemsSource = teachers;

            foreach(Teacher teacher in teachers)
            {
                foreach(Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
            }

            lbCourse.ItemsSource = courses;
        }
    }
}
