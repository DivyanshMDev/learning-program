using Confluent.Kafka;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafkaWindowsChatApp
{
    public partial class Form1 : Form
    {
        private IProducer<Null, string> producer;
        private IConsumer<Ignore, string> consumer;

        public Form1()
        {
            InitializeComponent();
            InitializeKafka();
        }

        private void InitializeKafka()
        {
            var producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
            producer = new ProducerBuilder<Null, string>(producerConfig).Build();

            var consumerConfig = new ConsumerConfig
            {
                GroupId = $"chat-gui-{Guid.NewGuid()}",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Latest
            };
            consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
            consumer.Subscribe("chat-messages");

            Task.Run(ConsumeMessages);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text)) return;

            var chatMessage = $"[{DateTime.Now:HH:mm:ss}] {txtUsername.Text}: {txtMessage.Text}";
            await producer.ProduceAsync("chat-messages", new Message<Null, string> { Value = chatMessage });
            txtMessage.Clear();
        }

        private void ConsumeMessages()
        {
            while (true)
            {
                var result = consumer.Consume();
                BeginInvoke(new Action(() =>
                {
                    txtMessages.AppendText($"{result.Message.Value}\r\n");
                }));
            }
        }
    }
}
