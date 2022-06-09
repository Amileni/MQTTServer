using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MQTTnet;
using MQTTnet.Server;
using MQTTnet.Protocol;
using MQTTnet.Formatter;
using MQTTnet.Implementations;
using MQTTnet.Client;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Text;

namespace MQTTServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static async Task Run_Server()
        {
            var server = new MqttFactory().CreateMqttServer();
            var serverOptions = new MqttServerOptionsBuilder()
                                    .WithDefaultEndpoint()
                                    .WithDefaultEndpointPort(707)
                                    .WithApplicationMessageInterceptor(OnNewMessage);

            await server.StartAsync(serverOptions.Build());
        }

        public static void OnNewMessage(MqttApplicationMessageInterceptorContext context)
        {
            var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);


        }
    }
}
