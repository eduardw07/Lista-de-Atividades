using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaskBox
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
            GerarGrade();
            listView1.ItemChecked += listView1_ItemChecked;
        }

        // Configurando a aparencia do meu ListView
        private void GerarGrade()
        {
            listView1.Columns.Add("Projeto", 70).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Descrição", 360);
            listView1.Columns.Add("%").TextAlign = HorizontalAlignment.Center;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
        }

        // Botão de excluir task.
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Checked)
                {
                    listView1.Items.RemoveAt(i);
                    AtualizarId();
                }
            }
            AtualizarPorcentagens();
        }

        // Botão de adicionar task.
        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new InputForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string descricao = form.Descricao;
                    if (!string.IsNullOrWhiteSpace(descricao))
                    {
                        string projeto = (listView1.Items.Count + 1).ToString();
                        string[] item = { projeto, descricao, "0%" };
                        var newItem = new ListViewItem(item);
                        listView1.Items.Add(newItem);
                    }
                }
            }
        }

        // Criando o metodo de mensagem para perguntar se o usuario realmente quer marcar como concluida a task e contabilizar como porcentagem.
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item;
            string descricao = item.SubItems[1].Text;

            if (item.Checked)
            {
                DialogResult result = MessageBox.Show("Deseja marcar esta tarefa como concluida?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    item.Checked = false;
                }
                else
                {
                    AtualizarPorcentagens();
                }
            }     
        }

        // Metodo para calcular a porcentagem mediante a caixinha marcada.
        private void AtualizarPorcentagens()
        {
            int totalTarefas = listView1.Items.Count;
            int tarefasConcluidas = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    tarefasConcluidas++;
                }
            }

            foreach (ListViewItem item in listView1.Items)
            {
                float porcentagem = totalTarefas == 0 ? 0 : (float)tarefasConcluidas / totalTarefas * 100;
                item.SubItems[2].Text = porcentagem.ToString("0") + "%";
            }
        }

        // Criando o metodo que atualiza o Id automaticamente.
        private void AtualizarId()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }
    }

    public class Atividades
    {
        public int Projeto { get; set; }
        public string Descricao { get; set; }
        public float Porcentagem { get; set; }

        public Atividades(int projeto, string descricao, float porcentagem)
        {
            this.Projeto = projeto;
            this.Descricao = descricao;
            this.Porcentagem = porcentagem;
        }
    }

    // Criando a telinha que vai aparecer quando clicar em Adicionar.
    public class InputForm : Form
    {
        private TextBox textBox1;
        private Button okButton;
        private Button cancelButton;

        public string Descricao { get; private set; }

        public InputForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();

            textBox1.Location = new System.Drawing.Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(260, 20);
            textBox1.TabIndex = 0;

            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new System.Drawing.Point(116, 40);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 25);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += new EventHandler(okButton_Click);

            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(198, 40);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 25);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;

            AcceptButton = okButton;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(284, 73);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(textBox1);
            Name = "InputForm";
            Text = "Nova Tarefa";
            ResumeLayout(false);
            PerformLayout();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Descricao = textBox1.Text;
        }
    }
}
