using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MultiShop.RabbitMQMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connettionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connettionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk1", false, false, false, arguments: null);

            var messageCountent = "Merhaba bu bir RabbitMQ kuyruk mesajıdır deneme";

            var byteMessageCountent = Encoding.UTF8.GetBytes(messageCountent);

            channel.BasicPublish(exchange: "", routingKey: "Kuyruk1", basicProperties: null, body: byteMessageCountent);

            return Ok("Mesajınız Kuyruğa Alınmıştır");
        }

        [HttpGet]
        public IActionResult ReadMessage()
        {


            var factory = new ConnectionFactory();

            factory.HostName = "localhost";

            var connection = factory.CreateConnection();

            using (var channel = connection.CreateModel())
            {
                // Kuyruğun var olduğundan emin olalım (pasif olarak kontrol edebiliriz)
                // Eğer kuyruk yoksa hata fırlatır. İsterseniz burada da QueueDeclare yapabilirsiniz.
                channel.QueueDeclare("Kuyruk1", false, false, false, arguments: null);

                // BasicGet kullanarak kuyruktan TEK bir mesaj çekmeyi deneyelim.
                // Bu metot, BasicConsume gibi sürekli dinlemez, anlık bir "çekme" işlemi yapar.
                BasicGetResult result = channel.BasicGet(queue: "Kuyruk1", autoAck: false);

                if (result is null)
                {
                    // Kuyrukta mesaj yoksa null döner.
                    return Ok("Kuyrukta okunacak mesaj bulunamadı.");
                }

                try
                {
                    var messageBody = result.Body.ToArray();
                    var message = Encoding.UTF8.GetString(messageBody);

                    // ÖNEMLİ: Mesajı başarıyla işledikten sonra RabbitMQ'ya bildirim gönderiyoruz.
                    // Bu komut, mesajın kuyruktan kalıcı olarak silinmesini sağlar.
                    // result.DeliveryTag: RabbitMQ'nun bu mesaja verdiği benzersiz kimliktir.
                    channel.BasicAck(deliveryTag: result.DeliveryTag, multiple: false);

                    return Ok(message);
                }
                catch (Exception)
                {
                    // Eğer mesajı işlerken bir hata olursa, mesajı onaylamayıp
                    // tekrar işlenmesi için kuyruğa geri gönderebiliriz (opsiyonel).
                    // channel.BasicNack(deliveryTag: result.DeliveryTag, multiple: false, requeue: true);

                    // Veya şimdilik sadece hata dönelim
                    return StatusCode(500, "Mesaj işlenirken bir hata oluştu.");
                }
            }










            //var consumer = new EventingBasicConsumer(channel);

            //consumer.Received += (model, body) =>
            //{
            //    var byteMessage = body.Body.ToArray();
            //    message = Encoding.UTF8.GetString(byteMessage);
            //};

            //channel.BasicConsume(queue: "Kuyruk3", autoAck: false, consumer: consumer);

            //if (string.IsNullOrEmpty(message))
            //{
            //    return NoContent();
            //}
            //else
            //{
            //    return Ok(message);
            //}
        }
    }
}
