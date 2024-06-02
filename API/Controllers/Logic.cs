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

                var query = $"SELECT * FROM messages_by_topic WHERE foro_id = ? LIMIT ?";
                var preparedStatement = _session.Prepare(query);
                var boundStatement = preparedStatement.Bind(foroid, last);
                var result = _session.Execute(boundStatement);

                return MapMessagesByForo(result);
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

                var startDate = DateTime.UtcNow.AddDays(-last);
                startDate = startDate.Date;
                var finishDate = DateTime.UtcNow.Date;

                var startTimestamp = DateTimeOffset.UtcNow.AddDays(-last).ToUnixTimeMilliseconds();

                var query = $"SELECT * FROM messages_by_topic WHERE topic_id = ? AND date >= ? AND date <= ? AND message_id >= ?  allow filtering";                
                
                var preparedStatement = _session.Prepare(query);
                var boundStatement = preparedStatement.Bind(topicid, startDate, finishDate, startTimestamp);
                var result = _session.Execute(boundStatement);

                return MapMessagesByTopic(result);
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
            return rows.Select(row => new MessagesByForo
            {
                ForoId = row.GetValue<Guid>("foro_id"),
                Date = row.GetValue<DateTime>("date"),
                MessageId = row.GetValue<Guid>("message_id"),
                TopicId = row.GetValue<Guid>("topic_id"),
                TopicName = row.GetValue<string>("topic_name"),
                UserName = row.GetValue<string>("user_name"),
                Text = row.GetValue<string>("texto"),
                Links = row.GetValue<List<string>>("links"),
                Hashtags = row.GetValue<List<string>>("hashtags")
            }).ToList();
        }

        private List<MessagesByTopic> MapMessagesByTopic(IEnumerable<Row> rows)
        {
            return rows.Select(row => new MessagesByTopic
            {
                TopicId = row.GetValue<Guid>("topic_id"),
                Date = row.GetValue<DateTime>("date"),
                MessageId = row.GetValue<Guid>("message_id"),
                ForoId = row.GetValue<Guid>("foro_id"),
                ForoName = row.GetValue<string>("foro_name"),
                UserName = row.GetValue<string>("user_name"),
                Text = row.GetValue<string>("texto"),
                Links = row.GetValue<List<string>>("links"),
                Hashtags = row.GetValue<List<string>>("hashtags")
            }).ToList();
        }

        private MessageById MapMessageById(Row row)
        {
            return new MessageById
            {
                MessageId = row.GetValue<Guid>("message_id"),
                Date = row.GetValue<DateTime>("date"),
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
