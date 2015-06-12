using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                bool achou = false;
                for (int i = 0; i < listBox1.Items.Count; i++)
                    if (listBox1.Items[i].ToString() == textBox10.Text)
                    {
                        achou = true;
                        break;
                    }
                if (!achou)
                    listBox1.Items.Add(textBox1.Text);
                else
                    MessageBox.Show("已存在该会员组!");
            }
            else
                MessageBox.Show("请输入会员组名称!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            else
                MessageBox.Show("请选择需要移除的会员组!");
        }

        private void click_diasMin(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void clickQuantidade(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void blockInfo(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tempopress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void levelpress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void itemidpress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar!=':')
                e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)//item
            {
                comando.Enabled = pocoes.Enabled = efeitospocao.Enabled = false;
                quantidade.Enabled = propriedadesitem.Enabled = items.Enabled = grupos.Enabled =encantamentos.Enabled = items.Enabled = true;
            }
            else if (comboBox1.SelectedIndex == 1)//pocao
            {
                comando.Enabled = items.Enabled = encantamentos.Enabled = items.Enabled = false;
                quantidade.Enabled = propriedadesitem.Enabled = pocoes.Enabled = grupos.Enabled = efeitospocao.Enabled = true;
            }
            else if (comboBox1.SelectedIndex == 2)//din
            {
                comando.Enabled = items.Enabled = efeitospocao.Enabled = encantamentos.Enabled = items.Enabled = propriedadesitem.Enabled = pocoes.Enabled = false;
                quantidade.Enabled = grupos.Enabled = true;
            }
            else if (comboBox1.SelectedIndex == 3)//exp
            {
                comando.Enabled = items.Enabled = efeitospocao.Enabled = encantamentos.Enabled = items.Enabled = propriedadesitem.Enabled = pocoes.Enabled = false;
                quantidade.Enabled = grupos.Enabled = true;
            }
            else if (comboBox1.SelectedIndex == 4) //cmd
            {
                quantidade.Enabled = items.Enabled = efeitospocao.Enabled = encantamentos.Enabled = items.Enabled = propriedadesitem.Enabled = pocoes.Enabled = false;
                comando.Enabled = grupos.Enabled = true;
            }
            else //msg
            {
                quantidade.Enabled = items.Enabled = efeitospocao.Enabled = encantamentos.Enabled = items.Enabled = propriedadesitem.Enabled = pocoes.Enabled = false;
                comando.Enabled = grupos.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox10.Text.Count(c => c == ':') > 1)
                MessageBox.Show("只有一个 ':'.");
            else
            {
                if (textBox10.Text.Count(c => c == ':') == 1)
                {
                    if (textBox10.Text.Split(':').Length != 2)
                        MessageBox.Show("正确格式: 物品ID:VALUE");
                    else
                    {
                        bool achou = false;
                        for (int i = 0; i < listBox4.Items.Count; i++)
                            if (listBox4.Items[i].ToString() == textBox10.Text)
                            {
                                achou = true;
                                break;
                            }
                        if (!achou)
                            listBox4.Items.Add(textBox10.Text);
                        else
                            MessageBox.Show("数值已存在!");
                    }
                }
                else
                {
                    bool achou = false;
                    for (int i = 0; i < listBox4.Items.Count;i++)
                        if (listBox4.Items[i].ToString()==textBox10.Text)
                        {
                            achou = true;
                            break;
                        }
                    if (!achou)
                        listBox4.Items.Add(textBox10.Text);
                    else
                        MessageBox.Show("数值已存在!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                try
                {
                    int i = int.Parse(textBox14.Text);
                    if (i > 0)
                    {
                        listBox3.Items.Add(listBox2.Items[listBox2.SelectedIndex].ToString() + "-" + int.Parse(textBox14.Text));
                        listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    }
                    else
                        MessageBox.Show("'附魔等级' 必须大于 0!");
                }
                catch
                {
                    MessageBox.Show("'附魔等级' 必须为数字!");
                }
            }
            else
                MessageBox.Show("请先在列表中选择一个物品!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                listBox2.Items.Add(listBox3.Items[listBox3.SelectedIndex].ToString().Split('-')[0]);
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
            }
            else
                MessageBox.Show("请先在列表中选择一个会员组!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox5.SelectedIndex != -1)
            {
                try
                {
                    int i = int.Parse(textBox12.Text);
                    int i2 = int.Parse(textBox13.Text);
                    if (i > 0 && i2 > 0)
                    {
                        listBox6.Items.Add(listBox5.Items[listBox5.SelectedIndex].ToString() + "-" + textBox12.Text + ":" + (int.Parse(textBox13.Text)-1));
                        listBox5.Items.RemoveAt(listBox5.SelectedIndex);
                    }
                    else
                        MessageBox.Show("'药水等级' 和 '时间' 必须大于 0!");
                }
                catch
                {
                    MessageBox.Show("'药水等级' 和 '时间' 必须为数字!");
                }
            }
            else
                MessageBox.Show("请先在列表中选择一个物品!");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox6.SelectedIndex != -1)
            {
                listBox5.Items.Add(listBox6.Items[listBox6.SelectedIndex].ToString().Split('-')[0]);
                listBox6.Items.RemoveAt(listBox6.SelectedIndex);
            }
            else
                MessageBox.Show("请先在列表中选择一个会员组!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if (listBox1.Items.Count == 0)
            {
                ok = false;
                MessageBox.Show("请先为会员组添加获得的奖励!");
            }
            try
            {
                int i = int.Parse(textBox2.Text);
                if (i < 0)
                {
                    ok = false;
                    MessageBox.Show("'天数' 必须大于 0!");
                }
            }
            catch
            {
                MessageBox.Show("'天数' 必须为数字!");
                ok = false;
            }
            try
            {
                if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex <= 1)
                {
                    int i = int.Parse(textBox3.Text);
                    if (i < 1 || i > 64)
                    {
                        MessageBox.Show("'数量' 必须在 0 ~ 64 之间!");
                        ok = false;
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    int i = int.Parse(textBox3.Text);
                    if (i < 1)
                    {
                        MessageBox.Show("'数量' 必须大于 0!");
                        ok = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("'数量' 必须为数字!");
                ok = false;
            }
            try
            {
                if (comboBox1.SelectedIndex == 2)
                {
                    double i = double.Parse(textBox3.Text);
                    if (i < 1)
                    {
                        MessageBox.Show("'数量' 必须大于 0!");
                        ok = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("'数量' 必须为数字!");
                ok = false;
            }
            if (ok)
            {
                if (comboBox1.SelectedIndex == 0)//item
                {
                    String grupos = "";
                    String enchants = "";
                    String ids = "";
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (grupos.Length == 0)
                            grupos = listBox1.Items[i].ToString();
                        else
                            grupos += "-" + listBox1.Items[i].ToString();
                    }
                    for (int i = 0; i < listBox4.Items.Count; i++)
                    {
                        if (ids.Length == 0)
                            ids = listBox4.Items[i].ToString();
                        else
                            ids += "-" + listBox4.Items[i].ToString();
                    }
                    for (int i = 0; i < listBox3.Items.Count; i++)
                    {
                        if (enchants.Length == 0)
                            enchants = listBox3.Items[i].ToString();
                        else
                            enchants += "-" + listBox3.Items[i].ToString();
                    }
                    if (textBox5.Text.Length != 0)
                    {
                        if (enchants.Length == 0)
                            enchants = "name-" + textBox5.Text;
                        else
                            enchants += "-name-" + textBox5.Text;
                    }
                    if (listBox7.Items.Count != 0)
                    {
                        for (int i = 0; i < listBox7.Items.Count; i++)
                        {
                            if (enchants.Length == 0)
                                enchants = "desc-" + listBox7.Items[i];
                            else
                                enchants += "-desc-" + listBox7.Items[i];
                        }
                    }
                    if (enchants.Length == 0)
                        enchants = "none";
                    resultado.Text = "- " + grupos + "," + textBox2.Text + "," + ids + "," + textBox3.Text + "," + enchants;
                }
                else if (comboBox1.SelectedIndex == 1)//pocao
                {
                    String grupos = "";
                    String enchants = "";
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (grupos.Length == 0)
                            grupos = listBox1.Items[i].ToString();
                        else
                            grupos += "-" + listBox1.Items[i].ToString();
                    }
                    for (int i = 0; i < listBox6.Items.Count; i++)
                    {
                        if (enchants.Length == 0)
                            enchants = listBox6.Items[i].ToString();
                        else
                            enchants += "-" + listBox6.Items[i].ToString();
                    }
                    if (textBox5.Text.Length != 0)
                    {
                        if (enchants.Length == 0)
                            enchants = "name-" + textBox5.Text;
                        else
                            enchants += "-name-" + textBox5.Text;
                    }
                    if (listBox7.Items.Count != 0)
                    {
                        for (int i = 0; i < listBox7.Items.Count; i++)
                        {
                            if (enchants.Length == 0)
                                enchants = "desc-" + listBox7.Items[i];
                            else
                                enchants += "-desc-" + listBox7.Items[i];
                        }
                    }
                    if (enchants.Length == 0)
                        enchants = "none";
                    resultado.Text = "- " + grupos + "," + textBox2.Text + ",potion:" + comboBox3.Items[comboBox3.SelectedIndex].ToString() + ":" + comboBox2.Items[comboBox2.SelectedIndex].ToString() + ":" + textBox8.Text + ":" + (int.Parse(textBox9.Text)-1) + "," + textBox3.Text + "," + enchants;
                }
                else if (comboBox1.SelectedIndex == 2)//din
                {
                    String grupos = "";
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (grupos.Length == 0)
                            grupos = listBox1.Items[i].ToString();
                        else
                            grupos += "-" + listBox1.Items[i].ToString();
                    }
                    resultado.Text = "- " + grupos + "," + textBox2.Text + ",$," + textBox3.Text;
                }
                else if (comboBox1.SelectedIndex == 3)//exp
                {
                    String grupos = "";
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (grupos.Length == 0)
                            grupos = listBox1.Items[i].ToString();
                        else
                            grupos += "-" + listBox1.Items[i].ToString();
                    }
                    resultado.Text = "- " + grupos + "," + textBox2.Text + ",xp," + textBox3.Text;
                }
                else if (comboBox1.SelectedIndex == 4) //cmd
                {
                    if (textBox11.Text.Length == 0)
                        MessageBox.Show("请输入执行的 '指令或消息'!");
                    else
                    {
                        String grupos = "";
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            if (grupos.Length == 0)
                                grupos = listBox1.Items[i].ToString();
                            else
                                grupos += "-" + listBox1.Items[i].ToString();
                        }
                        resultado.Text = "- "+grupos+","+textBox2.Text+",cmd,"+textBox11.Text;
                    }
                }
                else //msg
                {
                    if (textBox11.Text.Length == 0)
                        MessageBox.Show("请输入执行的 '指令或消息'!");
                    else
                    {
                        String grupos = "";
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            if (grupos.Length == 0)
                                grupos = listBox1.Items[i].ToString();
                            else
                                grupos += "-" + listBox1.Items[i].ToString();
                        }
                        resultado.Text = "- "+grupos+","+textBox2.Text+",msg,"+textBox11.Text;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(resultado.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex != -1)
                listBox4.Items.RemoveAt(listBox4.SelectedIndex);
            else
                MessageBox.Show("请选择需要移除的ID!");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox2.Text = "0";
            textBox3.Text = "1";
            comboBox1.SelectedIndex = 0;
            textBox5.Clear();
            textBox4.Clear();
            listBox7.Items.Clear();
            textBox8.Text = "1";
            textBox9.Text = "1";
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Text = "1";
            textBox13.Text = "1";
            textBox14.Text = "1";
            listBox3.Items.Clear();
            listBox2.Items.Clear();
            string[] r = { "power", "flame", "infinity", "punch", "sharpness", "baneofarthropods", "smite", "efficiency", "unbreaking", "fireaspect", "knockback", "fortune", "looting", "respiration", "protection", "blastprotection", "featherfalling", "fireprotection", "projectileprotection", "silktouch", "thorns", "aquaaffinity" };
            listBox2.Items.AddRange(r);
            string[] s = { "fireresistance", "instantdamage", "instantheal", "invisibility", "nightvision", "poison", "regen", "slowness", "speed", "strength", "water", "weakness" };
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox5.Items.AddRange(s);
            resultado.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox7.Items.Add(textBox4.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (listBox7.SelectedIndex != -1)
                listBox7.Items.RemoveAt(listBox7.SelectedIndex);
            else
                MessageBox.Show("请选择需要移除的描述!");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("power = 力量 \r\nflame = 火矢 \r\ninfinity = 无限 \r\npunch = 冲击 \r\nsharpness = 锋利 \r\nbaneofarthropods = 节肢杀手 \r\nsmite = 亡灵杀手 \r\nefficiency = 效率 \r\nunbreaking = 耐久 \r\nfireaspect = 火焰附加 \r\nknockback = 击退  \r\nfortune = 时运 \r\nlooting = 抢夺 \r\nrespiration = 水下呼吸 \r\nprotection = 保护 \r\nblastprotection = 爆炸保护 \r\nfeatherfalling = 摔落保护 \r\nfireprotection = 火焰保护 \r\nprojectileprotection = 弹射物保护 \r\nsilktouch = 精准采集 \r\nthorns = 荆棘 \r\naquaaffinity = 水下速掘");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("我没时间你们不要找我!");
        }



    }
}
