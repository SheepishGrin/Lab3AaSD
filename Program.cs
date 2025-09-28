
namespace ConsoleApp3
{
	internal class Program
	{
		static MyQueue[] temp;
		static MyQueue[] queue;
		static MyQueue tempi;
		static int navigation;
		static int l;

		static void Main(string[] args)
		{
			ChooseCountQueue();
            while (true)
			{
				Console.WriteLine("Лабораторная работа 3. Очереди");
				Console.WriteLine("Введите, что вы хотите сделать?\n" +
				"1. Создать/изменить очереди\n" +
				"2. Выполнить задание программы\n" +
				"3. Завершить программу\n" +
				"4. Изменить количество очередей (приведёт к потере данных)\n" +
				"5. Вывести список очередей");
				if (Int32.TryParse(Console.ReadLine(), out navigation))
					switch (navigation)
					{
						case 1:
							{
								Console.Clear(); QueueSelector(); break;
							}
						case 2:
							{
								LabsMission(); break;
							}
						case 3:
							{
								Console.Write("Программа завершила свою работу\nНажмите любую клавишу, чтобы завершить программу..."); Console.ReadLine();
								return;
							}
						case 4:
							{
								ChooseCountQueue(); break;
							}
						case 5:
							{
								PrintQueue(); break;
							}
						default:
							{
								Error("Неверно введён вариант ответа");
								break;
							}
					}
				else { Error("Неверно введён вариант ответа"); }
			}
			
			

			
			
		}
		static void ChooseCountQueue()
		{

			try
			{
				Console.WriteLine("Укажите количество очередей для работы:");
				int n = Convert.ToInt32(Console.ReadLine());
				queue = new MyQueue[n];
				for (int i = 0; i < queue.Length; i++) queue[i] = new MyQueue(0);
				Console.Clear();
			}
			catch (Exception) { Error("Введено неверное значение!"); }
			return;
		}
		static void LabsMission()
		{
			if (queue.Length > 1)
				for (int i = 0; i < queue.Length; i++)
				{
					for (int j = i + 1; j < queue.Length; j++)
					{
						try
						{
							if (Equals(queue[j], queue[i]))
							{
								Console.WriteLine($"Очереди {i + 1} и {j + 1} совпадают:\nОчередь {i + 1}:\n{queue[i].Queue()}\nОчередь {j + 1}:\n{queue[j].Queue()}");
							}
						}
						catch (Exception) { Error("Не все очереди заполнены!"); return; }
					}
				}
			else
			{
				Error("Для выполнения задания требуется от 2х очередей и больше!");
			}
			return;
		}
		static void PrintQueue()
		{
			try
			{
				string que = "";
				for (int i = 0; i < queue.Length; i++)
				{
					que += $"Очередь {i + 1}:\n" + queue[i].Queue() + "\n";
				}
				Console.WriteLine(que);
			}
			catch (Exception) { Error("Не все очереди заполнены! Сначала заполните каждую очередь!"); }
		}
		static void QueueSelector()
		{
			temp = queue;
			
			while (true)
			{
				Console.WriteLine($"У вас есть {temp.Length} очередей\n" +
				"1. Выбрать очередь\n" +
				"2. Завершить редактирование\n");
				if (Int32.TryParse(Console.ReadLine(), out navigation))
					switch (navigation)
					{
						case 1:
							{
								while (true)
								{
									Console.WriteLine($"Выберите очередь (от 1 до {temp.Length})");
									
									if (Int32.TryParse(Console.ReadLine(), out l))
									{
										try
										{
											tempi = temp[l - 1];
											QueueEditor();
											break;
										}
										catch (Exception) { Error("Указано неверное значение!"); }
									}
								}
								break;
							}
						case 2:
							{
								Console.Clear();
								queue = temp;
								return;
							}
						default:
							{
								Error("Неверно введён вариант ответа");
								break;
							}
					}
				else { Error("Неверно введён вариант ответа");}
				return;
			}
		
		}
		static void QueueEditor()
		{
			int navigation;
			while (true)
			{
				if (!tempi.Empty())
				{
					Console.WriteLine($"Выбрана {l} очередь:\n{tempi.Queue()}\n\nЧто вы хотите сделать?\n" +
						"1. Добавить элемент\n" +
						"2. Удалить элемент\n" +
						"3. Изменить элемент\n" +
						"4. Изменить количество элементов в очереди (приведёт к потере данных!)\n" +
						"5. Закончить редактирование");
					if (Int32.TryParse(Console.ReadLine(), out navigation))
						switch (navigation)
						{
							case 1:
								{
									AddElement(); break;
								}
							case 2:
								{
									RemoveElement(); break;
								}
							case 3:
								{
									ChangeElement(); break;
								}
							case 4:
								ChangeLengthQueue(); break;	
							case 5:
								{
									temp[l - 1] = tempi;
									Console.Clear();
									return;
								}
							default:
								{
									Error("Неверно введён вариант ответа");
									break;
								}
						}
					else
					{
						Error("Неверно введён вариант ответа");
					}
				}
				else
				{
					Console.WriteLine($"Выбрана {l} очередь. Она пуста!\nЧто вы хотите сделать?\n" +
						"1. Добавить элемент\n" +
						"2. Изменить количество элементов в очереди\n" +
						"3. Закончить редактирование");
					if (Int32.TryParse(Console.ReadLine(), out navigation))
						switch (navigation)
						{
							case 1:
								{
									AddElement(); break;
								}
							case 2:
								{
									ChangeLengthQueue(); break;
								}
							case 3:
								{
                                    temp[l - 1] = tempi;
                                    Console.Clear();
                                    return;
                                }
							default:
								{
									Error("Неверно введён вариант ответа");
									break;
								}
						}
					else
					{
						Error("Неверно введён вариант ответа");
					}
				}
			}
		}
		static void AddElement()
		{
			if (tempi.Length() > 0)
			{
				Console.WriteLine("Введите элемент, который хотите добавить в очередь:");
				try
				{
					tempi.Insert(Convert.ToInt32(Console.ReadLine()));
					Console.Clear();
				}
				catch (FormatException)	{ Error("Введено неверное значение!"); }
				catch (IndexOutOfRangeException) { Error("Очередь заполнена!"); }
			}

			else { Error("Размер очереди не определён!"); }
		}

		static void RemoveElement() {
			try
			{
				Console.WriteLine($"Будет удалён элемент {tempi.Peek()}. Вы уверены? (y/n)");
				string check1 = Console.ReadLine();
				if (check1 == "y") Console.WriteLine($"Был удалён элемент {tempi.Remove()}");
				else Console.WriteLine("Действие отклонено");
			}
			catch (IndexOutOfRangeException) { Error("Очередь и так пуста!"); }
			Console.Clear(); 
		}
		static void ChangeElement() {
			try
			{
				Console.WriteLine($"Будет изменён элемент {tempi.Peek()}. Вы уверены? (y/n)");
				string check2 = Console.ReadLine();
				if (check2 == "y")
				{
					Console.WriteLine("Введите элемент, на который хотите изменить:");
					try
					{
						tempi.Change(Convert.ToInt32(Console.ReadLine())); Console.Clear();
					}
					catch (FormatException) { Error("Введено неверное значение! Действие отклонено!"); }
				}
				else Console.WriteLine("Действие отклонено");
			}
			catch (IndexOutOfRangeException) { Error("Очередь пуста!"); } 
		}
		static void ChangeLengthQueue() {
			Console.WriteLine("Введите максимальное количество элементов, которое должно быть в очереди:");
			try
			{
				int n = Convert.ToInt32(Console.ReadLine());
				tempi = new MyQueue(n + 1);
				Console.Clear();
				Console.WriteLine($"Максимальный размер очереди: {n}");
			}
			catch (Exception) { Error("Введено неверное значение!"); } 
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
		static void Error(string Error)
		{
			Console.Clear();
			Console.WriteLine(Error + "\n");
		}
	}

}

class MyQueue
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
