using Cassandra;
using System.Collections.Generic;
using ISession = Cassandra.ISession;

namespace API.Controllers
{

    public class ForoLogic
    {
        private readonly ISession _session;

        public ForoLogic(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public List<MessagesByForo> GetMessagesByForo(Guid foroid ,int last)
        {
            try
            {
                List<MessagesByForo> messages = new List<MessagesByForo>();
                int days = 0;
                int remainingMessages = last;
                while (remainingMessages > 0) { 
                    var date = DateTime.UtcNow.Date.AddDays(-days);
                    var formattedDate = date.ToString("yyyy-MM-dd");
                    var formattedDate2 = Cassandra.LocalDate.Parse(formattedDate);
                    
                    var query = $"SELECT * FROM messages_by_foro WHERE foro_id = ? AND date = ? LIMIT ?";
                    var preparedStatement = _session.Prepare(query);
                    var boundStatement = preparedStatement.Bind(foroid, formattedDate2, remainingMessages);
                    RowSet result = _session.Execute(boundStatement);
                   
                    List<MessagesByForo> queryResult = MapMessagesByForo(result);
                    messages.AddRange(queryResult);
                    remainingMessages -= queryResult.Count;
                    days++;
       
                }
  
                return messages;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as required
                throw; // Rethrow the exception for the caller to handle
            }
        }

        public List<MessagesByTopic> GetMessagesByTopic(Guid topicid, int last)
        {
            try
            {

                List<MessagesByTopic> messages = new List<MessagesByTopic>();
                int days = 0;
                int remainingMessages = last;
                while (remainingMessages > 0)
                {
                    var date = DateTime.UtcNow.Date.AddDays(-days);
                    var formattedDate = date.ToString("yyyy-MM-dd");
                    var formattedDate2 = Cassandra.LocalDate.Parse(formattedDate);

                    var query = $"SELECT * FROM messages_by_topic WHERE topic_id = ? AND date = ? LIMIT ?";
                    var preparedStatement = _session.Prepare(query);
                    var boundStatement = preparedStatement.Bind(topicid, formattedDate2, remainingMessages);
                    var result = _session.Execute(boundStatement);

                    List<MessagesByTopic> queryResult = MapMessagesByTopic(result);
                    messages.AddRange(queryResult);
                    remainingMessages -= queryResult.Count;
                    days++;
                }

                return messages;

            }
            catch (Exception ex)
            {
                // Log or handle the exception as required
                throw; // Rethrow the exception for the caller to handle
            }
        }

        public MessageById GetMessageById(Guid id)
        {
            try
            {
                var query = $"SELECT * FROM messages_by_id WHERE message_id = {id}";
                var result = _session.Execute(query).FirstOrDefault();

                if (result == null)
                    return null;

                return MapMessageById(result);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as required
                throw; // Rethrow the exception for the caller to handle
            }
        }

        private List<MessagesByForo> MapMessagesByForo(IEnumerable<Row> rows)
        {
            List<MessagesByForo> messages = new List<MessagesByForo>();

            foreach (var row in rows)
            {
                LocalDate localDate = row.GetValue<LocalDate>("date");
                DateTime date = new DateTime(localDate.Year, localDate.Month, localDate.Day);

                MessagesByForo message = new MessagesByForo
                {
                    ForoId = row.GetValue<Guid>("foro_id"),
                    Date = date, // Convert LocalDate to DateTime
                    MessageId = row.GetValue<Guid>("message_id"),
                    TopicId = row.GetValue<Guid>("topic_id"),
                    TopicName = row.GetValue<string>("topic_name"),
                    UserName = row.GetValue<string>("user_name"),
                    Text = row.GetValue<string>("texto"),
                    Links = row.GetValue<List<string>>("links"),
                    Hashtags = row.GetValue<List<string>>("hashtags")
                };

                messages.Add(message);
            }

            return messages;
        }

        private List<MessagesByTopic> MapMessagesByTopic(IEnumerable<Row> rows)
        {

            List<MessagesByTopic> messages = new List<MessagesByTopic>();


            foreach (var row in rows)
            {
                LocalDate localDate = row.GetValue<LocalDate>("date");
                DateTime date = new DateTime(localDate.Year, localDate.Month, localDate.Day);

                MessagesByTopic message = new MessagesByTopic
                {
                    TopicId = row.GetValue<Guid>("topic_id"),
                    Date = date,
                    MessageId = row.GetValue<Guid>("message_id"),
                    ForoId = row.GetValue<Guid>("foro_id"),
                    ForoName = row.GetValue<string>("foro_name"),
                    UserName = row.GetValue<string>("user_name"),
                    Text = row.GetValue<string>("texto"),
                    Links = row.GetValue<List<string>>("links"),
                    Hashtags = row.GetValue<List<string>>("hashtags")
                };
                messages.Add(message);
            }

            return messages;
        }

        private MessageById MapMessageById(Row row)
        {
             LocalDate localDate = row.GetValue<LocalDate>("date");
             DateTime date = new DateTime(localDate.Year, localDate.Month, localDate.Day);


            return new MessageById
            {
                MessageId = row.GetValue<Guid>("message_id"),
                Date = date,
                TopicId = row.GetValue<Guid>("topic_id"),
                ForoId = row.GetValue<Guid>("foro_id"),
                UserName = row.GetValue<string>("user_name"),
                Text = row.GetValue<string>("texto"),
                Links = row.GetValue<List<string>>("links"),
                Hashtags = row.GetValue<List<string>>("hashtags")
            };
        }
    }
}
