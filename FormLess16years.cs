//Autor Alexandr Roslyakov
/*Program to find students with random fake studetns with random with the creation of fake people*/
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23_variant_CSharp_5_2_1
{
    public partial class FormStudentsLess16 : Form
    {
        public FormStudentsLess16()
        {
            InitializeComponent();
        }

        enum Group : byte
        { 
            ИТз341, АКиТ11, МЕз224, ИМ421, ПОз213
        }
        enum SurnameMen : byte
        {
            Росляков, Иванов, Кузнецов, Соколов, Попов, Лебедев, Козлов, Новиков, Морозов, Петров, Волков, Соловьёв, Васильев,
            Зайцев, Павлов, Семёнов, Голубев, Виноградов, Богданов, Воробьёв, Фёдоров, Михайлов, Беляев, Тарасов, Белов,
            Комаров, Орлов, Киселёв, Макаров, Андреев, Ковалёв, Ильин, Гусев, Титов, Кудрявцев
        }
        enum NameMen : byte
        {
            Александр, Даниил, Алексей, Кирилл, Сергей, Никита, Андрей, Артём, Дмитрий, Иван, Михаил, Пётр, Павел,
            Егор, Илья, Матвей, Константин, Максим, Виктор, Григорий, Антон, Владимир, Артур, Валентин, Евгений
        }
        
        enum PatronymicMen : byte
        {
            Алексеевич, Александрович, Анатольевич, Андреевич, Антонович, Аркадьевич, Артемович, Бедросович, Богданович,
            Борисович, Валентинович, Валерьевич, Васильевич, Викторович, Витальевич, Владимирович, Владиславович, Вячеславович,
            Геннадиевич, Григорьевич, Данилович, Денисович, Дмитриевич, Евгеньевич, Егорович, Иванович, Игнатьевич, Игоревич,
            Кириллович, Константинович, Леонидович, Максимович, Михайлович, Николаевич, Олегович, Павлович, Петрович, Романович,
            Сергеевич, Станиславович, Тарасович, Федорович, Ярославович
        }
        enum NameWomen : byte
        {
            Елена, Анастасия, Дарья, Анна, Ксения, Наталья, Мария, Ольга, Александра, Светлана, Софья, Юлия,
            Полина, Ирина, Елизавета, Екатерина, Валерия, Татьяна, Василиса, Марина, Виолетта, Евгения
        }

        enum PatronymicWomen : byte
        {
            Александровна, Алексеевна, Анатольевна,
            Андреевна, Антоновна, Артемовна, Богдановна, Борисовна, Валентиновна, Валерьевна, Васильевна, Викторовна, Виталиевна, 
            Владимировна,Владиславовна, Вячеславовна, Геннадиевна, Георгиевна, Григорьевна, Даниловна, Денисовна, Дмитриевна, Евгеньевна, 
            Егоровна, Ефимовна, Ивановна, Игоревна, Кирилловна, Константиновна, Леонидовна, Михайловна, Николаевна, Олеговна, Павловна, 
            Романовна, Семеновна, Сергеевна, Станиславовна, Степановна, Тарасовна, Тимофеевна, Федоровна, Феликсовна, Филипповна, Эдуардовна,
            Юрьевна, Ярославовна
        }

        int yearNow = DateTime.Now.Year;                             //текущий год
        int age;                                                                //возраст
        bool gender, grants;                                                    //пол, стипендия
        int studentsCount = 100;                                                 //кол-во студентов в группах
        int paramColumn = 8;                                                    //кол-во столбцов (параметров)
        Random rnd = new Random();
        bool otlichnDvoech = false;                                             //для классификации
        float summGrades = 0;                                                   //сумма оценок студента
        float AverVal = 0;                                                       //среднее значение
        int countGradesTable = 3;                                               //кол-во столбцов с оценками

        private void checkBoxLess16years_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int LengthSurnameMen = Enum.GetNames(typeof(SurnameMen)).Length;                 //возвращает кол-во элементов
            int LengthGroup = Enum.GetNames(typeof(Group)).Length;
            int LengthNameMen = Enum.GetNames(typeof(NameMen)).Length;
            int LengthPatronymicMen = Enum.GetNames(typeof(PatronymicMen)).Length;
            int LengthNameWomen = Enum.GetNames(typeof(NameWomen)).Length;
            int LengthPatronymicWomen = Enum.GetNames(typeof(PatronymicWomen)).Length;

            SurnameMen n = (SurnameMen)rnd.Next(LengthSurnameMen);                                    //случайный элемент
            dataGridView1.RowCount = studentsCount;                                       //кол-во строк
            dataGridView1.ColumnCount = paramColumn;                                                 //столбцов
            dataGridView1.Columns[0].HeaderText = "Группа";
            dataGridView1.Columns[1].HeaderText = "Фамилия, Имя, Отчество";
            dataGridView1.Columns[2].HeaderText = "Год рождения";
            dataGridView1.Columns[3].HeaderText = "Пол";
            dataGridView1.Columns[4].HeaderText = "Оценки по физике";
            dataGridView1.Columns[5].HeaderText = "Оценки по математике";
            dataGridView1.Columns[6].HeaderText = "Оценки по информатике";
            dataGridView1.Columns[7].HeaderText = "Стипендия";

            Group group = (Group)rnd.Next(LengthGroup);
            SurnameMen surnameMen = (SurnameMen)rnd.Next(LengthSurnameMen);
            NameMen nameMen = (NameMen)rnd.Next(LengthNameMen);
            PatronymicMen patronymicMen = (PatronymicMen)rnd.Next(LengthPatronymicMen);
            NameWomen nameWomen = (NameWomen)rnd.Next(LengthNameWomen);
            PatronymicWomen patronymicWomen = (PatronymicWomen)rnd.Next(LengthPatronymicWomen);

            //dataGridView1.Rows[0].HeaderCell.Value = "Группа " + group;
            int rowsCount = studentsCount;
            int columnCount = paramColumn;
            string[,] tableStudents = new string[rowsCount, columnCount];

            string grades()
            {
                int x; 
                string outRnd = null;
                if (otlichnDvoech == false)
                {
                x = rnd.Next(1, 4);
                outRnd += x + " ";
                }
                else
                {
                    x = rnd.Next(3, 6);
                    outRnd += x + " ";
                }
                summGrades += x;
                return outRnd;
            }
            for (int count_row = 0; count_row < studentsCount; count_row++)
            {
                age = yearNow - rnd.Next(14, 21);
                if (checkBoxLess16years.Checked && age < yearNow-16)
                    break;

                gender = Convert.ToBoolean(rnd.Next(2));                                //вероятность 1/2
                otlichnDvoech = Convert.ToBoolean(rnd.Next(2));

                //age
                tableStudents[count_row, 2] = age.ToString();
                dataGridView1.Rows[count_row].Cells[2].Value = tableStudents[count_row, 2];

                group = (Group)rnd.Next(LengthGroup);
                tableStudents[count_row, 0] = Convert.ToString(group);
                dataGridView1.Rows[count_row].Cells[0].Value = tableStudents[count_row, 0]; 

                for (int count_column = 0; count_column < paramColumn; count_column++)
                {
                    if (gender == true)
                    {
                        surnameMen = (SurnameMen)rnd.Next(LengthSurnameMen);
                        tableStudents[count_row, 1] = Convert.ToString(surnameMen) + " ";
                        dataGridView1.Rows[count_row].Cells[1].Value = tableStudents[count_row, 1];

                        nameMen = (NameMen)rnd.Next(LengthNameMen);
                        tableStudents[count_row, 1] += Convert.ToString(nameMen) + " ";
                        dataGridView1.Rows[count_row].Cells[1].Value = tableStudents[count_row, 1];

                        patronymicMen = (PatronymicMen)rnd.Next(LengthPatronymicMen);
                        tableStudents[count_row, 1] += Convert.ToString(patronymicMen);
                        dataGridView1.Rows[count_row].Cells[1].Value = tableStudents[count_row, 1];

                        tableStudents[count_row, 3] = "Муж.".ToString();
                        dataGridView1.Rows[count_row].Cells[3].Value = tableStudents[count_row, 3];

                    }
                    else
                    {
                        surnameMen = (SurnameMen)rnd.Next(LengthSurnameMen);
                        tableStudents[count_row, 1] = Convert.ToString(surnameMen) + "а ";
                        dataGridView1.Rows[count_row].Cells[1].Value = tableStudents[count_row, 1];

                        nameWomen = (NameWomen)rnd.Next(LengthNameWomen);
                        tableStudents[count_row, 1] += Convert.ToString(nameWomen) + " ";
                        dataGridView1.Rows[count_row].Cells[1].Value = ' ' + tableStudents[count_row, 1];

                        patronymicWomen = (PatronymicWomen)rnd.Next(LengthPatronymicWomen);
                        tableStudents[count_row, 1] += Convert.ToString(patronymicWomen) + " ";
                        dataGridView1.Rows[count_row].Cells[1].Value = tableStudents[count_row, 1];

                        tableStudents[count_row, 3] = "Жен.".ToString();
                        dataGridView1.Rows[count_row].Cells[3].Value = tableStudents[count_row, 3];

                    }


                    for(int k=4, count=0; k < 7; k++)
                    {
                        tableStudents[count_row, k] += grades()+ ' ';
                        dataGridView1.Rows[count_row].Cells[k].Value = tableStudents[count_row, k];
                        count++;
                    }
                }

                AverVal = summGrades / (paramColumn * countGradesTable);
                if (AverVal >= 4)                                                           //если средняя оценка по предметам больше или равна 4
                {
                    grants = true;
                    tableStudents[count_row, 7] = "Да".ToString();
                    dataGridView1.Rows[count_row].Cells[7].Value = tableStudents[count_row, 7];
                }
                else
                {
                    grants = false;
                    tableStudents[count_row, 7] = "Нет".ToString();
                    dataGridView1.Rows[count_row].Cells[7].Value = tableStudents[count_row, 7];
                }
                AverVal = 0;                                                                            //обнуляем переменные
                summGrades = 0;
                label1.Text = n.ToString();
            }

            try
            {
                string writePath = @"C:\521\students.txt";
                /*Дополнительное задание: При каждом запуске приложения 1 нужно ДОПИСЫВАТЬ массив 
                 * в текстовый файл(т.е.при каждом запуске программы нужно добавлять данные к имеющимся в файле)*/
                //Для этого воспользуемся 2м параметром(true/false) в последовательном символьном потоке  StreamWriter,
                //который разрешает/запрещает запись в файл
                //Группа, ФИО, Год рождения, Оценки, Стипендия
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    for (int count_row = 0; count_row < studentsCount; count_row++)
                    {
                        for (int count_column = 0; count_column < paramColumn; count_column++)
                        {
                            sw.Write(tableStudents[count_row, count_column]);
                            sw.Write (',');
                        }
                        sw.Write("\n");
                    }
                    sw.Close();
                }

            }
            catch (Exception wrong)
            {
                Console.WriteLine("Error:" + wrong.Message);
                Console.ReadKey();
                return;
            }


        }



    }
}
