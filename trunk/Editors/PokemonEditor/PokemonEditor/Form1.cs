using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IAPL.Pokemon;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PokemonEditor
{
    public partial class Form1 : Form
    {
        PokemonList pokemon;

        public Form1()
        {
            pokemon = new PokemonList();
            InitializeComponent();
            typeOne.SelectedText = typeOne.Text = "Bug";
            typeTwo.SelectedText = typeTwo.Text = "Blank";
            expTypeBox.SelectedText = expTypeBox.Text = "Slow - 1,250,000";
            PDexNumber.Text = "";
            PDexNumber.Text += pokemon.numberOfPokemon + 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openPokemonListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            pokemon = (PokemonList)formatter.Deserialize(stream);
            stream.Close();
            
            updateList();
        }

        private void savePokemonListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, pokemon);
            stream.Close();
        }

        private void addPokemonButton_Click(object sender, EventArgs e)
        {
            bool listAdd = true;
            if (pokemon.pokemon.ContainsKey(Convert.ToInt32(PDexNumber.Text)))
            {
                listAdd = false;
            }

            BasePokemon newPoke = new BasePokemon(nameBox.Text
                , typeOne.Text
                , typeTwo.Text
                , Convert.ToInt32(baseHP.Text)
                , Convert.ToInt32(baseAttack.Text)
                , Convert.ToInt32(baseDefense.Text)
                , Convert.ToInt32(baseSPAtk.Text)
                , Convert.ToInt32(baseSPDef.Text)
                , Convert.ToInt32(baseSpeed.Text)
                , Convert.ToInt32(PDexNumber.Text)
                , pdexEntry.Text
                , expTypeBox.Text.Split(new Char[] {' '})[0]);

            debugTest.Text = "name" + newPoke.Name + "t1" + newPoke.baseTypeOne +" exp " + newPoke.EXP;

            pokemon.addPokemon(newPoke);
            if (listAdd)
            {
                pokeListBox.Items.Add(newPoke.Name);
                PDexNumber.Text = Convert.ToString(Convert.ToInt32(PDexNumber.Text) + 1);
            }
        }

        private void updateList()
        {
            if (pokemon.numberOfPokemon > 0)
            {
                pokeListBox.Items.Clear();
                String[] poke = new String[pokemon.numberOfPokemon];
                for (int i = 0; i < pokemon.numberOfPokemon; i++)
                {
                    poke[i] = pokemon.pokemon.Values[i].Name;
                }
                pokeListBox.Items.AddRange(poke);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BasePokemon temp = null;
            if (pokeListBox.SelectedItem != null)
            {
                temp = pokemon.getPokemon((String)pokeListBox.SelectedItem);
                nameBox.Text = temp.Name;
                baseHP.Text = Convert.ToString(temp.baseHP);
                baseAttack.Text = Convert.ToString(temp.baseAttack);
                baseDefense.Text = Convert.ToString(temp.baseDefense);
                baseSPAtk.Text = Convert.ToString(temp.baseSPAttack);
                baseSPDef.Text = Convert.ToString(temp.baseSPDefense);
                baseSpeed.Text = Convert.ToString(temp.baseSpeed);
                typeOne.Text = Convert.ToString(temp.baseTypeOne);
                typeTwo.Text = Convert.ToString(temp.baseTypeTwo);

                expTypeBox.Text = "";
                switch (temp.EXP)
                {
                    case EXPType.Erratic:
                        expTypeBox.Text = "Erratic - 600,000";
                        break;
                    case EXPType.Fast:
                        expTypeBox.Text = "Fast - 800,000";
                        break;
                    case EXPType.Fluctuating:
                        expTypeBox.Text = "Fluctuating - 1,640,000";
                        break;
                    case EXPType.MedFast:
                        expTypeBox.Text = "MedFast - 1,000,000";
                        break;
                    case EXPType.MedSlow:
                        expTypeBox.Text = "MedSlow - 1,059,860";
                        break;
                    case EXPType.Slow:
                        expTypeBox.Text = "Slow - 1,250,000";
                        break;
                    default:
                        break;
                }

                PDexNumber.Text = Convert.ToString(temp.PDexNo);
                pdexEntry.Text = temp.PDexEntry;
            }
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            if (pokemon.getPokemon(nameBox.Text) != null)
            {
                addPokemonButton.Text = "Change";
            }
            else
            {
                addPokemonButton.Text = "Add";
            }
        }
    }
}
