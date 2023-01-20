using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2 {
  public partial class Form1: Form {
    int[,] globalMatrix;
    public Form1() {
      InitializeComponent();
      Random rand = new Random();
      string s;
      globalMatrix = new int[rand.Next(4, 10), rand.Next(4, 10)];
      textBox9.Clear();
      for (int i = 0; i < globalMatrix.GetLength(0); i++) {
        s = "";
        for (int j = 0; j < globalMatrix.GetLength(1); j++) {
          globalMatrix[i, j] = rand.Next(100, 999);
          if (s.Length > 0) s = s + ",";
          s = s + globalMatrix[i, j].ToString();
        }
        if (textBox9.Text.Length > 0) textBox9.Text += Environment.NewLine;
        textBox9.Text += s;
      }
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
      e.Handled = !(char.IsControl(e.KeyChar) || ((((TextBox)sender).Text.Length < 4) && char.IsDigit(e.KeyChar)));
    }

    private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
      e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == ',');
    }

    /*Задание 1*/
    int multiplicationNumbers(int value) /*Задание 1*/ {
      int result = 1;
      int num = value;
      int rem;
      while (num > 0) {
        num = Math.DivRem(num, 10, out rem); // Деление 2 чисел с остатком и занос в переменную num 
        result *= rem;
      }
      return result;
    }

    string replaceText(string value) /*Задание 2*/ {
      return value.Replace(',', '!'); // Замена запятой на воскл знак
    }

    int[] arraySwap(int[] value) /*Задание 3*/{
      int[] nums = (int[])value.Clone();
      int minIndex = 0;
      int maxIndex = 0;
      for (int i = 1; i < nums.Length; i++) {
        if (nums[i] < nums[minIndex])
          minIndex = i; // Нахождение мин индекса
        if (nums[i] > nums[maxIndex])
          maxIndex = i; // Нахождение макс индекса
      }
      if (nums[minIndex] % 2 + nums[maxIndex] % 2 == 0) // Проверка на кратность 2
      {
        int temp = nums[minIndex];
        nums[minIndex] = nums[maxIndex]; // Сортировка
        nums[maxIndex] = temp;
      }
      return nums;
    }

    int[] arraySortFrom(int[] value, int startIndex) /*Задание 4*/{
      int temp;
      int[] nums = (int[])value.Clone(); // Создание массива
      for (int i = startIndex; i < nums.Length - 1; i++) // С какого числа startIndex
        for (int j = i + 1; j < nums.Length; j++) // Цикл сортировки
          if (nums[i] > nums[j]) {
            temp = nums[i];
            nums[i] = nums[j]; // Метод пузырька
            nums[j] = temp;
          }
      return nums; // Вывод
    }
    Tuple<int, int> arraySumAndMul(int[,] value) /*Задание 5*/{
      int sum = 0; // } присваивание 0
      int mul = 0; // } присваивание 0

      for (int i = 0; i < value.GetLength(0); i++) { // Переборка массива
        for (int j = 0; j < value.GetLength(1); j++) // Переборка массива
          if (value[i, j] % 3 + value[i, j] % 5 == 0) { // Проверка на кратность 3 и 5
            if (mul == 0) mul = 1; // Условие на 0, = 1
            sum += value[i, j]; // Сложение элементов
            mul *= value[i, j]; // Умножение элементов
          }
      }
      return Tuple.Create(sum, mul); // Вывод
    }

    int[,] arrayProcessing(int[,] value) /*Задание 6*/{
      int minNum = 999;
      int maxNum = 0;
      List<(int, int)> mins = new List<(int, int)>(); // Создание списка

      for (int i = 0; i < value.GetLength(0); i++) { // Переборка массива 
        for (int j = 0; j < value.GetLength(1); j++) { // Переборка массива
          if (value[i, j] < minNum && rightNumber(value[i, j])) { // Проверка одинаковых чисел
            if (mins.Count > 0) mins.Clear(); // Поиск минимума среди массива
            mins.Add((i, j)); // Берется это число
            minNum = value[i, j]; // Приравнивание элемента к минимуму
          } else if (value[i, j] == minNum) { // Иначе если элемент равен минимуму
            mins.Add((i, j)); // Просто остается это число
          }
          if (value[i, j] > maxNum) // Если элемент больше максимума
            maxNum = value[i, j]; // Присваивание элемента к максимуму
        }
      }
      int[,] matrix = (int[,])value.Clone(); // Берем двумерную матрицу
      for (int i = 0; i < mins.Count; i++) // Прогоняем ее
        matrix[mins[i].Item1, mins[i].Item2] = maxNum; // Замена числа на максимум

      return matrix; // Вывод

      bool rightNumber(int valueNum) { // Описание t/f метода (одинаковые числа)
        string s = valueNum.ToString(); // Создание переменной и конвертирование в строку
        for (int i = 0; i < s.Length - 1; i++) // Переборка массива
          for (int j = i + 1; j < s.Length; j++) // Переборка массива
            if (s[i] == s[j]) // Если число равно другому числу
              return true; // Вывод true
        return false; // Иначе вывод false
      }
    }

    int[,] newMatrix(int[,] value) /*Задание 7*/{
      int[,] matrix = new int[value.GetLength(0), value.GetLength(1)]; // Создание матрицы
      for (int i = 0; i < value.GetLength(0); i++) // Переборка массива
        for (int j = 0; j < value.GetLength(1); j++) // Переборка массива
          matrix[i, j] = 2 * value[i, j]; // Каждый элемент умножается на 2 
      return matrix;
    }

    private void button1_Click(object sender, EventArgs e) {
      if (textBox1.Text.Length == 0)
        label1.Text = "Поле ввода пустое!";
      else
        label1.Text = "Произведение всех цифр числа = " + multiplicationNumbers(Convert.ToInt32(textBox1.Text)).ToString();
    }

    private void button2_Click(object sender, EventArgs e) {
      textBox3.Text = replaceText(textBox2.Text);
    }

    private void button3_Click(object sender, EventArgs e) {
      int[] aa = Array.ConvertAll(textBox4.Text.Split(','), s => int.Parse(s));
      textBox5.Text = string.Join(",", arraySwap(aa).Select(x => x.ToString()).ToArray());
    }

    private void button4_Click(object sender, EventArgs e) {
      int[] aa = Array.ConvertAll(textBox6.Text.Split(','), s => int.Parse(s));
      textBox7.Text = string.Join(",", arraySortFrom(aa, (int)numericUpDown1.Value).Select(x => x.ToString()).ToArray());
    }

    private void button5_Click(object sender, EventArgs e) {
      string[] numsLine = textBox8.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
      string[] nums = numsLine[0].Split(',');
      int[,] aa = new int[numsLine.Length, nums.Length];

      for (int i = 0; i < numsLine.Length; i++) {
        if (numsLine[i].Trim().Length > 0) {
          nums = numsLine[i].Split(',');
          for (int j = 0; j < nums.Length; j++)
            aa[i, j] = Convert.ToInt32(nums[j]);
        }
      }

      Tuple<int, int> sumAndMul = arraySumAndMul(aa);

      label5.Text = "Сумма = " + sumAndMul.Item1.ToString();
      label6.Text = "Произведение = " + sumAndMul.Item2.ToString();
    }

    private void button6_Click(object sender, EventArgs e) {
      string[] numsLine = textBox9.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
      string[] nums = numsLine[0].Split(',');
      int[,] a = new int[numsLine.Length, nums.Length];

      for (int i = 0; i < numsLine.Length; i++) {
        if (numsLine[i].Trim().Length > 0) {
          nums = numsLine[i].Split(',');
          for (int j = 0; j < nums.Length; j++)
            a[i, j] = Convert.ToInt32(nums[j]);
        }
      }
      a = arrayProcessing(a);

      textBox10.Clear();
      string s;
      for (int i = 0; i < a.GetLength(0); i++) {
        s = "";
        for (int j = 0; j < a.GetLength(1); j++) {
          if (s.Length > 0) s = s + ",";
          s = s + a[i, j].ToString();
        }
        textBox10.AppendText(s + Environment.NewLine);
      }
    }

    private void button7_Click(object sender, EventArgs e) {
      string[] numsLine = textBox12.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
      string[] nums = numsLine[0].Split(',');
      int[,] a = new int[numsLine.Length, nums.Length];

      for (int i = 0; i < numsLine.Length; i++) {
        if (numsLine[i].Trim().Length > 0) {
          nums = numsLine[i].Split(',');
          for (int j = 0; j < nums.Length; j++)
            a[i, j] = Convert.ToInt32(nums[j]);
        }
      }
      a = newMatrix(a);

      textBox11.Clear();
      string s;
      for (int i = 0; i < a.GetLength(0); i++) {
        s = "";
        for (int j = 0; j < a.GetLength(1); j++) {
          if (s.Length > 0) s = s + ",";
          s = s + a[i, j].ToString();
        }
        textBox11.AppendText(s + Environment.NewLine);
      }
    }
  }
}