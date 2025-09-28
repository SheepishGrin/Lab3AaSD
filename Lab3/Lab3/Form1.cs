
namespace Lab3
{
	public partial class Form1 : Form
	{
		public MyQueue[] myQueues;
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				userControl11.tempi = myQueues[Int32.Parse(textBox1.Text) - 1];
			}
			catch (FormatException) { MessageBox.Show("Действие отклонено. Введено некорректное значение"); return; }
			catch (NullReferenceException) { MessageBox.Show("Очередей для редактирования нет!"); return; }
			catch (IndexOutOfRangeException) { MessageBox.Show("Действие отклонено. Введено некорректное значение"); return; }
			userControl11.label1.Text = $"Выбрана очередь {Int32.Parse(textBox1.Text)}";
			if (!userControl11.tempi.Empty())
			{
				userControl11.label2.Text = "Текущая очередь: " + userControl11.tempi.Queue();
			}
			else
			{
				userControl11.label2.Text = "Здесь будет выведена очередь(на данный момент очередь пуста)";
			}
			if (userControl11.tempi.Length() > 0) userControl11.label3.Text = $"Размер очереди - {userControl11.tempi.Length()}";
			else userControl11.label3.Text = "Размер очереди - 0";
			userControl11.textBox1.Text = "";
			textBox1.ReadOnly = true;
			textBox2.ReadOnly = true;
			button1.Enabled = false;
			button2.Enabled = false;
			button3.Enabled = false;
			button4.Visible = true;
			userControl11.Visible = true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show($"Вы действительно хотите изменить количество очередей? (это приведёт к полному стиранию значений всех очередей)", "Удаление элемента", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
			{
				try
				{
					myQueues = new MyQueue[Int32.Parse(textBox2.Text)];
					for (int j = 0; j < myQueues.Length; j++)
					{
						myQueues[j] = new MyQueue(0);
					}
					label1.Text = $"Всего {Int32.Parse(textBox2.Text)} очередей";
				}
				catch (FormatException) { MessageBox.Show("Действие отклонено. Введено некорректное значение"); }
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			for (int p = 0; p < myQueues.Length; p++)
			{
				if (myQueues[p].Empty()) { MessageBox.Show("Не все очереди заполнены!"); return; }
			}
			if (myQueues.Length > 1)
				for (int p = 0; p < myQueues.Length; p++)
				{
					for (int j = p + 1; j < myQueues.Length; j++)
					{
						if (Equals(myQueues[j], myQueues[p]))
						{
							listBox1.Items.Add($"Очереди {p + 1} и {j + 1} совпадают:");
							listBox1.Items.Add($"Очередь {p + 1}: {myQueues[p].Queue()}");
							listBox1.Items.Add($"Очередь {j + 1}: {myQueues[j].Queue()}");


						}
					}
				}
			else
			{
				MessageBox.Show("Для выполнения задания требуется от 2х очередей и больше!");
			}
			return;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			myQueues[Int32.Parse(textBox1.Text) - 1] = userControl11.tempi;
			Console.WriteLine(myQueues[Int32.Parse(textBox1.Text) - 1].Queue());
			textBox1.ReadOnly = false;
			textBox2.ReadOnly = false;
			button1.Enabled = true;
			button2.Enabled = true;
			button3.Enabled = true;
			userControl11.Visible = false;
			button4.Visible = false;
		}
        static bool Equals(MyQueue q1, MyQueue q2)
        {
            if (q1.LengthElems() != q2.LengthElems()) return false;
            bool areEqual = true;
            int Length = q1.LengthElems();
            for (int i = 0; i < Length; i++)
            {
                int elem1 = q1.Peek();
                int elem2 = q2.Peek();
                if (elem1 != elem2)
                {
                    areEqual = false;
                    break;
                }
            }
            return areEqual;
        }
    }
}
