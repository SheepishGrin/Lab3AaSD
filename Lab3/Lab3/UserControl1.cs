
using Microsoft.VisualBasic;

namespace Lab3
{
	public partial class UserControl1 : UserControl
	{
		public MyQueue tempi;
		public UserControl1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int value;
			if (Int32.TryParse(Interaction.InputBox("Введите значение в очередь (целое чилсло до 2 147 483 647)", "Ввод значения", "0"), out value))
			{
				tempi.Insert(value);
				label2.Text = "Текущая очередь: " + tempi.Queue();
			}
			else MessageBox.Show("Действие отклонено или введено некорректное значение!");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show($"Вы действительно хотите удалить элемент {tempi.Peek()} из стека?", "Удаление элемента", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
				{
					tempi.Remove();
					string st = tempi.Queue();
					label2.Text = (st == "") ? "Здесь будет выведена очередь (на данный момент очередь пуста)" : "Текущий стек: " + st;
				}
			}
			catch (IndexOutOfRangeException) { MessageBox.Show("Очередь пустая. Введите значения в очередь!"); }
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				int arg;
				if (MessageBox.Show($"Вы действительно хотите изменить элемент {tempi.Peek()} из очереди?", "Удаление элемента", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
					if (Int32.TryParse(Interaction.InputBox("Введите значение, на которое хотите поменять (целое чилсло до 2 147 483 647)", "Ввод значения", "0"), out arg))
					{
						tempi.Change(arg);
						label2.Text = "Текущий стек: " + tempi.Queue();

						//Дальше балуемся с интерфейсом
					}
					else
						MessageBox.Show("Действие отклонено. Введено некорректное значение");
			}
			catch (IndexOutOfRangeException) { MessageBox.Show("Очередь пустая. Введите значения в очередь!"); }
		}

		private void button4_Click(object sender, EventArgs e)
		{
			int n;
			if (Int32.TryParse(textBox1.Text, out n))
			{
				tempi = new MyQueue(n);
				label2.Text = "Здесь будет выведена очередь (на данный момент очередь пуста)";
				label3.Text = "Размер стека равен " + n.ToString();
			}
			else MessageBox.Show("Действие отклонено. Введено некорректное значение!");
		}




	}
	public partial class MyQueue
	{
		int maxSize = 0;
		int[] Q;
		int H = 0;
		int K = 0;

		public MyQueue(int maxSize)
		{
			this.maxSize = maxSize;
			Q = new int[maxSize];
		}

		public void Insert(int elem)
		{
			if ((K + 1) % maxSize == (H % maxSize)) throw new IndexOutOfRangeException();
			int T = K++ % maxSize;
			Q[T] = elem;
		}
		public int Remove()
		{
			if (Empty()) throw new IndexOutOfRangeException();
			int elem = Peek();
			H++;
			return elem;
		}
		public bool Empty()
		{
			return (K == H);
		}
		public int Peek()
		{
			if (Empty()) throw new IndexOutOfRangeException();
			return Q[H % maxSize];
		}
		public void Rotate()
		{
			int elem = Remove();
			Insert(elem);
		}
		public void Change(int x)
		{
			Q[H % maxSize] = x;
		}
		public int Length() { return maxSize; }

		public int LengthElems() { return K - H; }
		public string Queue()
		{
			string res = "";
			for (int i = 0; i < (K - H) % maxSize; i++)
			{
				res += Peek().ToString() + " ";
				Rotate();
			}
			return res;
		}

		

	}
}
