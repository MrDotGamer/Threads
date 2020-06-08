using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//1)  Formoje vartotojas gali nurodyti kintamą kiekį thread(atšakos) (Nuo 2 iki 15, kiekis negali būti didesnis ar mažesnis).
//2)  Išrinkus kiekį ir paspaudus start mygtuką, kiekvienas thread turi atsitiktiniu laiko intervalu(0,5-2 sekundžių) generuoti 5-10 (atsitiktinai) simbolių ilgio eilutę.
//3)  Turi būti įsimenamos/rodomos 20 paskutinių sugeneruotų duomenų, kurie išvedami į formos ListView kontrolą.ListView turi tokias kolonas – Thread ID(numeris atšakos, kur numeruojama nuo 1), sugeneruota eilutė.
//4)  Visi atšakos generuoti duomenis rašomi į access duomenų failą(mdb) (galite naudoti ir SQL serverį, jie turite tokią galimybę), lentelę - kur laukai yra ID(autonumber), ThreadID, Time(laikas sugeneravimo), Data(eilutė).
//5)  Paspaudus Stop mygtuką darbas stabdomas ir thread išjungiamos.
namespace UVS
{
    public partial class Form1 : Form
    {
        const string Connection = "Server=(local)\\sqlexpress;Database=ThreadData;Trusted_Connection=True;MultipleActiveResultSets = true";
        const string Symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public bool CanWork { get; set; }
        Thread[] threadsArray = null;
        int total_thread_num;
        public delegate void PopulateListview();
        PopulateListview populateView;

        public Form1()
        {
            populateView = new PopulateListview(PopulateListView);
            CanWork = true;
            InitializeComponent();
            populateView();
        }

        private void PopulateListView()
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand query = new SqlCommand("SELECT top 20 ThreadId,Data FROM ThreadII ORDER BY ID DESC", con);
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    PopulateListView();
                }));
                return;
            }
            if(thread_lv != null)
            {
                thread_lv.Items.Clear();
            }
            try
            {
                con.Open();
                SqlDataReader sdr = query.ExecuteReader();
                while (sdr.Read())
                {
                    ListViewItem item = new ListViewItem(sdr["Data"].ToString());
                    item.SubItems.Add(sdr["ThreadId"].ToString());
                    thread_lv.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :{0}", e);
            }
            finally
            {
                con.Close();
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            CanWork = true;
            ThreadGenerator();
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            CanWork = false;
        }

        private void ThreadGenerator()
        {
            total_thread_num = Convert.ToInt32(Math.Round(thread_count_nud.Value, 0));
            threadsArray = null;
            threadsArray = new Thread[total_thread_num];
            for (int i = 0; i < total_thread_num; i++)
            {
                threadsArray[i] = new Thread(()=>Generator());
                threadsArray[i].Name = (i+1).ToString();
                threadsArray[i].Start();
                Thread.Sleep(100);
                Console.WriteLine("Thread nr {0} start",i);
            }
        }

        private void Generator()
        {
            try
            {
                while (CanWork)
                {
                    Thread.Sleep(Random_Interval(500, 2000));
                    DataGenerator();
                }
            }
            catch (ThreadInterruptedException)
            {
                Thread.CurrentThread.Interrupt();
            }
            finally
            {
                    Thread.CurrentThread.Interrupt();
                    Console.WriteLine("Thread sekmingai sustabdytas");
            }
        }

        public void DataGenerator()
        {
            int thread_nr = int.Parse(Thread.CurrentThread.Name);
            DateTime dateTimeNow = DateTime.Now;
            Random random = new Random();
            int size = Random_Interval(5, 10);
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Symbols[random.Next(Symbols.Length)];
                builder.Append(ch);
            }
            DataWriter(thread_nr, dateTimeNow, builder.ToString());  
            Console.WriteLine("thread nr {0} data: {1} timestamp {2}", thread_nr, builder.ToString(), dateTimeNow);
        }

        private void DataWriter(int thread_nr, DateTime dateTime, string thread_data)
        {
            SqlConnection con;
            SqlCommand com;
            con = new SqlConnection(Connection);
            con.Open();
            com = new SqlCommand("insert into ThreadII(Data,ThreadId,Date) values('" + thread_data + "'," + thread_nr + ",'" + dateTime + "')", con);
            try
            {
                com.ExecuteNonQuery();
                Console.WriteLine("Saved...");
                populateView();
            }
            catch (Exception e)
            {
                Console.WriteLine("Not Saved (Exception {0}):", e);
            }
            finally
            {
                con.Close();
            }
        }

        private static int Random_Interval(int min, int max)
        {
            Random interval = new Random();
            return interval.Next(min, max);
        }

        private void CreateDataTable()
        {
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand(@"CREATE TABLE dbo.ThreadII
                (
                    ID int IDENTITY(1, 1) NOT NULL,
                    Data nvarchar(10) NULL,
                    ThreadId int  NULL,
                    Date datetime NULL,
                    CONSTRAINT pk_id PRIMARY KEY(ID)
                )", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}
