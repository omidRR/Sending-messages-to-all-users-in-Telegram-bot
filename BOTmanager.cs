using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using File = System.IO.File;

namespace REXBOT
{
    public partial class REXBOT : MaterialSkin.Controls.MaterialForm
    {
        [Obsolete]
        public REXBOT()
        {
            var matskin = MaterialSkinManager.Instance;
            InitializeComponent();
            matskin.AddFormToManage(this);
            Load += Form1_Load;
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.Instance.ColorScheme = new ColorScheme(Color.Tomato, Color.Tomato,
                Color.GreenYellow, Color.DarkBlue, TextShade.WHITE);
        }
        TelegramBotClient Bot = new TelegramBotClient(token: GETtokenform.token);
        //braye log pm ma
        Dictionary<long, string> pm = new Dictionary<long, string>();
        ListViewItemSelectionChangedEventArgs listViewItem;
        public Task<User> botidme;
        private Telegram.Bot.Types.Message ee;
        public static string filedir;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("RE") == false)
            {
                System.IO.Directory.CreateDirectory("RE");

            }

            if (File.Exists("RE\\id.txt") == false)
            {
                System.IO.File.WriteAllText("RE\\id.txt", "");
            }
            if (File.Exists("RE\\Success.txt") == false)
            {
                System.IO.File.WriteAllText("RE\\Success.txt", "");
            }

            if (File.Exists("RE\\failed.txt") == false)
            {
                System.IO.File.WriteAllText("RE\\failed.txt", "");
            }
        }

        [Obsolete]
        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {

                var receiverOptions = new ReceiverOptions
                {
                    AllowedUpdates = new UpdateType[]
                    {
                        UpdateType.Message,
                        UpdateType.EditedMessage,
                        UpdateType.CallbackQuery,
                        UpdateType.ChosenInlineResult,
                        UpdateType.InlineQuery,
                        UpdateType.PollAnswer,
                        UpdateType.Unknown,
                        UpdateType.ChatMember,
                    }
                };

                Bot.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions);
                if (Bot.BotId != null)
                {
                    materialButton1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() => { richTextBox2.Text += "error client: " + ex.Message + "\n"; }));
                Bot.SendTextMessageAsync(683692798, "Error!!\n" + ex.Message);
            }
        }

        private async Task ErrorHandler(ITelegramBotClient bot, Exception update, CancellationToken arg3)
        {
            await bot.SendTextMessageAsync(683692798, "Error!!\n" + update.Message);
        }

        private async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            this.ee = update.Message;
            try
            {
                //list id ha
                this.Invoke(new Action(() =>
                {
                    var lineCount = 0;
                    using (var reader = System.IO.File.OpenText("RE\\id.txt"))
                    {
                        while (reader.ReadLine() != null)
                        {
                            lineCount++;
                        }

                        materialLabel8.Text = lineCount.ToString();
                    }
                }));
                if (update.Message.From.Id.ToString() == ("683692798"))
                {

                    if (update.Message.Text == "/send")
                    {
                        SendThemAll();
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                if (File.Exists(@"RE\id.txt") == false)
                {
                    System.IO.File.WriteAllText(@"RE\\id.txt", "");
                }

            }
            catch (System.IO.DirectoryNotFoundException)
            {
            }
            catch (Exception ex)
            {
                richTextBox2.Text = ex.Message;
            }

            //    A = e;
            try
            {
                using (StreamWriter sw = System.IO.File.AppendText("RE\\id.txt"))
                {
                    if (update.Message.Chat.Type == ChatType.Private)
                    {
                        var z = update.Message.From.Id.ToString();
                        await sw.WriteLineAsync(z);
                    }
                }

                //tekrari
                String[] TextFileLines = System.IO.File.ReadAllLines("RE\\id.txt");
                TextFileLines = TextFileLines.Distinct().ToArray();
                System.IO.File.WriteAllLines("RE\\id.txt", TextFileLines);
            }
            catch (DirectoryNotFoundException)
            {
                if (Directory.Exists("RE") == false)
                {
                    System.IO.Directory.CreateDirectory("RE");

                }
            }
            catch (Exception)
            {

            }

            try
            {
                //savechat
                this.Invoke(new Action(() =>
                {
                    ListViewItem memberView = new ListViewItem();
                    memberView.Text = update.Message.From.Id.ToString();
                    memberView.SubItems.Add(update.Message.From.FirstName);
                    memberView.SubItems.Add(update.Message.Chat.Title);
                    memberView.SubItems.Add(update.Message.From.Username);
                    memberView.SubItems.Add(DateTime.Now.ToString("yyyy/MM/dd | HH:mm"));
                    //تکراری نباشه
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].Text == memberView.Text)
                        {

                            return;
                        }
                    }

                    listView1.Items.Add(memberView);
                }));
                if (update.Message == null)
                {
                    return;
                }

                if (pm.ContainsKey(update.Message.From.Id))
                {
                    pm[update.Message.From.Id] += "\n" + update.Message.Text;
                }
                else
                {
                    var Chat = await Bot.GetChatAsync(chatId: update.Message.Chat.Id);
                    string Linkkk = Chat.InviteLink;
                    if (update.Message.Chat.Username == null)
                    {
                        update.Message.Chat.Username = "[NULL]";
                    }

                    pm.Add(update.Message.From.Id, ("Group ID:" + update.Message.Chat.Id + "  ID:" + update.Message.From.Id +
                                               "    name:" + update.Message.From.FirstName
                                               + "   Username:" + update.Message.From.Username + "\nPublicGP:" + update.Message.Chat.Username ?? "کاربر یوزر نیم ندارد" +
                                               "\nLINKGP:  " + Linkkk +
                                               "     \nchat: \n" +
                                               update.Message.Text + " \n "));
                }


            }
            catch
            {

            }
        }

        private async void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = pm[Convert.ToInt64(listViewItem.Item.Text)];

            }
            catch (Exception list)
            {
                this.Invoke(new Action(() => { richTextBox2.Text += "list: " + list.Message + "\n"; }));
                await Bot.SendTextMessageAsync(683692798, "Error list!!!!\n" + list.Message);

            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            listViewItem = e;
        }

        //[Obsolete]
        //private async void Client_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        //{

        //}

        [Obsolete]
        private void materialButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ee == null)
                {
                    MessageBox.Show("robot not started !\n first click 'connect'\n and /start your bot");
                    return;
                }

                SendThemAll();
                MessageBox.Show("Started!");
            }
            catch (DirectoryNotFoundException)
            {
                if (Directory.Exists("RE") == false)
                {
                    System.IO.Directory.CreateDirectory("RE");
                }

            }
            catch (Exception)
            {

            }
        }



        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch1.Checked)
            {
                materialSingleLineTextField1.Visible = true;
                materialSingleLineTextField3.Visible = true;
            }
            else if (materialSwitch1.Checked == false)
            {
                materialSingleLineTextField1.Visible = false;
                materialSingleLineTextField3.Visible = false;
            }
        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (materialTextBox1.Text == (""))
                {
                    MessageBox.Show("Enter a text for send!");
                    return;
                }


                richTextBox1.Text += "\nMyPM: " + materialTextBox1.Text + "\n";
                if (materialTextBox1.Text == "")
                {
                    return;
                }

                if (listViewItem == null)
                {
                    return;
                }

                await Bot.SendTextMessageAsync(listViewItem.Item.Text, materialTextBox1.Text);
            }
            catch (Exception listboxx)
            {
                this.Invoke(new Action(() => { richTextBox2.Text += "listbox: " + listboxx.Message + "\n"; }));
                await Bot.SendTextMessageAsync(683692798, "Error!!!!!\n" + listboxx.Message);
            }
        }
        private void materialSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch2.Checked)
            {
                SkinManager.Theme = MaterialSkinManager.Themes.DARK;
                SkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.DeepOrange800, Primary.Pink900,
                    Accent.Yellow700, TextShade.WHITE);
            }

            if (materialSwitch2.Checked == false)
            {
                SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                MaterialSkinManager.Instance.ColorScheme = new ColorScheme(Color.Tomato, Color.Tomato,
                    Color.GreenYellow, Color.DarkBlue, TextShade.WHITE);
            }
        }

        private void materialButton4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = pm[Convert.ToInt64(listViewItem.Item.Text)];

            }
            catch (Exception list)
            {
                await Bot.SendTextMessageAsync(683692798, "Error list!!!!\n" + list.Message);

            }
        }

        public async void SendThemAll(string path = "RE\\id.txt", long sent = 0, long failed = 0, string toSend = "")
        {
            ;
            this.Invoke(new Action(() => { toSend = richTextBox3.Text; }));
            try
            {
                if (toSend == null)
                {
                    MessageBox.Show("Your text message is empty");
                    return;
                }

                InlineKeyboardMarkup shisheMarkup = null;

                if (materialSwitch1.Checked == true)
                {

                    //shishebtc
                    shisheMarkup = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithUrl(materialSingleLineTextField1.Text,
                                materialSingleLineTextField3.Text),
                        },

                    });
                }


                var lines = System.IO.File.ReadAllLines(path);
                List<long> OkList = new List<long>();
                foreach (var line in lines)
                {
                    if (long.TryParse(line, out long id))
                    {
                        try
                        {
                            if (filedir != null)
                            {
                                FileStream fsSource = new FileStream(filedir, FileMode.Open, FileAccess.Read);
                                await Bot.SendPhotoAsync(id, fsSource, toSend, ParseMode.Markdown,
                                    replyMarkup: shisheMarkup);
                                OkList.Add(id);


                                //////remove ok send from id!!
                                String[] removelist = System.IO.File.ReadAllLines(path);
                                var cxListremovelist = removelist.Distinct().ToList();
                                cxListremovelist.Remove(id.ToString());
                                System.IO.File.WriteAllLines(path, cxListremovelist);



                                System.IO.File.WriteAllLines("RE\\Success.txt", OkList.Select(x => x.ToString()));
                                sent++;
                                fsSource.Dispose();
                            }
                            else
                            {
                                await Bot.SendTextMessageAsync(id, toSend, ParseMode.Markdown,
                                    replyMarkup: shisheMarkup);
                                OkList.Add(id);
                                System.IO.File.WriteAllLines("RE\\Success.txt", OkList.Select(x => x.ToString()));
                                sent++;
                            }

                        }
                        catch (ApiRequestException)
                        {
                            failed++;

                            using (StreamWriter sw = System.IO.File.AppendText("RE\\failed.txt"))
                            {
                                //
                                var z = id.ToString();
                                await sw.WriteLineAsync(z);
                            }

                            //////remove duplicate from ids!!
                            String[] removelist = System.IO.File.ReadAllLines(path);
                            var cxListremovelist = removelist.Distinct().ToList();
                            cxListremovelist.Remove(id.ToString());
                            System.IO.File.WriteAllLines(path, cxListremovelist);
                            //tekrari failed
                            String[] TextFileLines = System.IO.File.ReadAllLines("RE\\failed.txt");
                            TextFileLines = TextFileLines.Distinct().ToArray();
                            System.IO.File.WriteAllLines("RE\\failed.txt", TextFileLines);


                        }
                        catch (Exception ex)
                        {
                            richTextBox2.Text = ex.Message + "\n";
                            failed++;
                            sent++;
                            SendThemAll();
                        }
                    }
                    materialLabel7.Text = failed.ToString();
                    materialLabel4.Text = sent.ToString();
                }
            }
            catch (Exception exception)
            {
                this.Invoke(new Action(() => { richTextBox2.Text += "sendmessall: " + exception.Message + "\n"; }));
            }
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                filedir = openFileDialog1.FileName;
                label2.Text = openFileDialog1.FileName;
            }
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            filedir = null;
            pictureBox1.Image = null;
            label2.Text = null;
        }
    }
}