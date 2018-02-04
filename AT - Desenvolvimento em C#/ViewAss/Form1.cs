using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Domain;

namespace ViewAss
{
    public partial class Form1 : Form
    {

        Function manager = new Function();
        private Pessoa id;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            manager.StreamReaderCheck();
            dataAniversario();
            dataGridView1.Visible = false;
            txt_apresentacao.Visible = true;           
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void txt_matri_TextChanged(object sender, EventArgs e)
        {
            this.txt_matri.MaxLength = 9;
        }

        private void txt_cp_TextChanged(object sender, EventArgs e)
        {
            this.txt_cp.MaxLength = 9;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string searchValue = txt_search.Text;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResult = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().Equals(searchValue))
                        {
                            int rowIndex = row.Index;
                            dataGridView1.Rows[rowIndex].Selected = true;
                            valueResult = true;
                            break;
                        }
                    }

                }
                if (!valueResult)
                {
                    MessageBox.Show("Não foi possível achar " + txt_search.Text, "Pessoa ainda não cadastrada");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btn_adicionarPessoa_Click(object sender, EventArgs e)
        {
            txt_apresentacao.Visible = false;

            try
            {
                manager.addPessoa(txt_nome.Text, txt_aniversario.Text, txt_matri.Text, txt_cp.Text);
                MessageBox.Show("Pessoa cadastrada com Sucesso ", "Warning");
                manager.BuscarPessoa();

                var dataList = new BindingList<Pessoa>(manager.BuscarPessoa());
                var dataSource = new BindingSource(dataList, "");

                dataGridView1.DataSource = dataSource;
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Veja as opções que podem estar causando erro : \n1 - Coloque  a DATA DE NASCIMENTO em Mês/Dia/Ano \n2 - Caracteres inválidos, use somente letras ou números \n3 - Matrícula e CPF somente números.");
            }

        }


        private void Mostrar_Lista_Click(object sender, EventArgs e)
        {
            txt_apresentacao.Visible = false;

            try
            {
                manager.BuscarPessoa();

                var dataList = new BindingList<Pessoa>(manager.BuscarPessoa());
                var dataSource = new BindingSource(dataList, "");

                dataGridView1.DataSource = dataSource;
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show(" Não existe uma lista!! Crie uma Pessoa.");
            }
        }

        public void dataAniversario()
        {
            foreach (Pessoa p in manager.pessoas)
            {
                DateTime DateToday = new DateTime(DateTime.Today.Year, p.Date.Month, p.Date.Day);

                if (DateToday == DateTime.Today)
                {
                    MessageBox.Show("Não se esqueça de dar os parabéns para " + p.Name, "ANIVERSARIANTES QUE COMEMORAM  HOJE: ", MessageBoxButtons.OK);
                }
            }

        }


        private void btn_delete_Click(object sender, EventArgs e)
        {
            txt_apresentacao.Visible = false;
            manager.delPessoa(id);

                if (MessageBox.Show("Certeza que quer deletar esta Pessoa?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                    {
                        if (oneCell.Selected)
                            dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                    }
                }
            }
        }

    }



