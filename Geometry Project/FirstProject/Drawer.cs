﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProject
{
    public partial class Drawer : Form
    {
        public Drawer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }

        Dot A;
        Dot B;
        Dot C;
        Cube cube;
        Pyramid pyramid;
        Figure cur;
        Tetrahedron tetr;
        List<Label> lbl = new List<Label>();
        List<Label> Vlbl = new List<Label>();
        int zoom = 1;
        
        Graphics g;
        void Draw(Figure fig)
        {
            g = CreateGraphics();
            Dot O = new Dot(this.Size.Width / 2, this.Size.Height / 2, 0);

            g.Clear(Color.White);

            g.DrawLine(Pens.Black, (float)O.X, 0, (float)O.X, this.Size.Height);
            g.DrawLine(Pens.Black, 0, (float)O.Y, this.Size.Width, (float)O.Y);

            if (lbl.Count() != fig.Vertex.Length)
            {
                foreach (Label lab in lbl)
                {
                    lab.Size = new Size(0, 0);
                }
                lbl.Clear();
                Label[] lblArr = new Label[fig.Vertex.Length];
                for (int i = 0; i < fig.Vertex.Length; i++)
                {
                    lblArr[i] = new Label();
                    lblArr[i].Location = new Point((int)(zoom * fig.Vertex[i].X + O.X), (int)(O.Y - (zoom) * fig.Vertex[i].Y));
                    lblArr[i].Size = new Size(20, 20);
                    lblArr[i].BackColor = Color.White;
                    lblArr[i].Text = i.ToString();
                    lblArr[i].Parent = this;
                    this.Controls.Add(lblArr[i]);
                }
                lbl.AddRange(lblArr);
            }
            else
            {
                for (int i = 0; i < fig.Vertex.Length; i++)
                    lbl[i].Location = new Point((int)(zoom * fig.Vertex[i].X + O.X), (int)(O.Y - (zoom) * fig.Vertex[i].Y));
            }

            foreach (Edge edge in fig.Edges)
            {
                Point Ap = new Point((int)(zoom * (edge.Fr.X) + O.X), (int)(O.Y - (zoom) * edge.Fr.Y));
                Point Bp = new Point((int)(zoom * (edge.Sc.X) + O.X), (int)(O.Y - (zoom) * edge.Sc.Y));
                g.DrawLine(Pens.Red, Ap, Bp);
            }

            
            

                
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            zoom = trackBar1.Value;
            if (cur != null)
                Draw(cur);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dot O = new Dot(this.Size.Width / 2, this.Size.Height / 2, 0);
            if (textBox1.Text == "" || Get(textBox1) || textBox1.Text == "????") textBox1.Text = "????";
            else if (textBox2.Text == "" || Get(textBox2) || textBox2.Text == "????") textBox2.Text = "????";
            else if (textBox3.Text == "" || Get(textBox3) || textBox3.Text == "????") textBox3.Text = "????";
            else if (textBox4.Text == "" || Get(textBox4) || textBox4.Text == "????") textBox4.Text = "????";
            else if (textBox5.Text == "" || Get(textBox5) || textBox5.Text == "????") textBox5.Text = "????";
            else if (textBox6.Text == "" || Get(textBox6) || textBox6.Text == "????") textBox6.Text = "????";
            else if (textBox7.Text == "" || Get(textBox7) || textBox7.Text == "????") textBox7.Text = "????";
            else if (textBox8.Text == "" || Get(textBox8) || textBox8.Text == "????") textBox8.Text = "????";
            else if (textBox9.Text == "" || Get(textBox9) || textBox9.Text == "????") textBox9.Text = "????";
            else
            {
                A = new Dot(Convert.ToDouble(textBox1.Text),
                        Convert.ToDouble(textBox2.Text),
                        Convert.ToDouble(textBox3.Text));
                B = new Dot(Convert.ToDouble(textBox6.Text),
                        Convert.ToDouble(textBox5.Text),
                        Convert.ToDouble(textBox4.Text));
                C = new Dot(Convert.ToDouble(textBox9.Text),
                        Convert.ToDouble(textBox8.Text),
                        Convert.ToDouble(textBox7.Text));

                if (Line.IsOnOneLine(A, B, C))
                {
                    comboBox1.Text = "on one line!";
                    return;
                }

                if (comboBox1.Text == "Cube")
                {
                    cube = new Cube(A, B, C);
                    Draw(cube);
                    cur = cube;

                    CreateLabels(cube);
                    
                    
                }
                else if (comboBox1.Text == "Pyramid")
                {
                    pyramid = new Pyramid(A, B, C);
                    Draw(pyramid);
                    cur = pyramid;

                    CreateLabels(pyramid);
                }
                else if (comboBox1.Text == "Tetrahedron")
                {
                    tetr = new Tetrahedron(A, B, C);
                    Draw(tetr);
                    cur = tetr;
                    CreateLabels(tetr);
                }
                else comboBox1.Text = "Fill this";

            }

        }

        private void CreateLabels(Figure fig)
        {

            if (Vlbl.Count() != fig.Vertex.Length)
            {
                foreach (Label lab in Vlbl)
                {
                    lab.Size = new Size(0, 0);
                }
                Vlbl.Clear();
                Label[] lblArr = new Label[fig.Vertex.Length];
                for (int i = 0; i < fig.Vertex.Length; i++)
                {
                    lblArr[i] = new Label();
                    lblArr[i].Location = new Point(0, 500 + i * 25);
                    lblArr[i].Size = new Size(200, 20);
                    lblArr[i].Text = i.ToString() + $": ( {Math.Round(fig.Vertex[i].X, 3)}, {Math.Round(fig.Vertex[i].Y, 3)}, {Math.Round(fig.Vertex[i].Z, 3)})";
                    lblArr[i].Parent = this;
                    this.Controls.Add(lblArr[i]);
                }
                Vlbl.AddRange(lblArr);
            }
            

            
        }

        public bool Get(TextBox box)
        {
            double answer;
            if (double.TryParse(box.Text, out answer))
                return false;
            return true;

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
