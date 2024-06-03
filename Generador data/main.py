import uuid
from uuid import UUID
import time

import json
from datetime import datetime
import uuid
import random


def replace_quotes(file_path):
    # Read the content of the file
    with open(file_path, 'r') as file:
        content = file.read()

    # Replace double quotes with single quotes
    modified_content = content.replace('"', "'")

    # Write the modified content back to the file
    with open(file_path, 'w') as file:
        file.write(modified_content)


def generate_random_date():
    year = random.randint(2024, 2024)
    month = random.randint(5, 5)
    day = random.randint(20, 31)  # Assuming all months have 28 days for simplicity
    hour = random.randint(0, 23)
    minute = random.randint(0, 59)
    second = random.randint(0, 59)
    return datetime(year, month, day, hour, minute, second)

# Generate 10 random UUIDs for foro_id
foro_ids = [str(uuid.uuid4()) for _ in range(3)]

# Generate 20 random UUIDs for topic_id
topic_ids = [str(uuid.uuid4()) for _ in range(20)]

users_ids = [str(uuid.uuid4()) for _ in range(50)]

# Define names for topics and forums
topic_names = [
    "Connot connect server issue",
    "Newbie, things Idd like to see -common with other games-",
    "I feel dumb, how to eat?",
    "Online play candt - message error",
    "[PC][Steam][1.0.38.0.29][co-op] Player 2 having graphic issues?",
    "Please add 4 player co-op option",
    "4 player online coop / local splitscreen online coop",
    "[PC][1.0.38.0.29][Multi]Box container",
    "[PC][1.0.38.0.29][Raft Building] Cant destroy raft bases after attaching",
    "[PC][1.0.38.0.29][Multi]When I connect to HOST the game crashes after a few seconds",
    "[PC Steam] [1.0.31.0.25] [General/World] Items - containers missing when returning from another island",
    "What the hell is going on?",
    "Bad multiplayer plase fix",
    "Online loading is too slow",
    "[PC][1.0.38.0.29][Game Play] Yellow Starting Crates unable to attach to Container Shelf",
    "[Epic][1.0.38.0][Coop] Coop moving raft",
    "[PC][Steam][Epic][Gamepass] [1.0.17][1.0.31][1.0.38] [Raft] Raft causing error - NullPointerException if unloaded with the sail up",
    "Looking for a friend to play this game with",
    "Is the labelmaker still disabled in coop?"
]
forum_names = [
"[PC] General Discussion",
"[PC] Bug Reports",
"[PC] Suggestions",
]

usernames = [
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure",
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure",
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure",
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure",
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure",
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure",
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure",
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure",
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure",
    "emotionsFusion",
    "adjectivesBliss",
    "verbsVoyage",
    "nounsNexus",
    "adverbsAdventure",
    "pronounsPursuit",
    "prepositionsPath",
    "conjunctionsCatalyst",
    "interjectionsInnovation",
    "articlesAdventure"
    ]
hashtags = [
    "#GamingCommunity",
    "#GamerLife",
    "#GameOn",
    "#GamingNight",
    "#GamingSession",
    "#GamingFun",
    "#GamingWorld",
    "#GamingAddict",
    "#GamingLover",
    "#GamingFever",
    "#GamingMadness",
    "#GamingObsession",
    "#GamingPassion",
    "#GamingRush",
    "#GamingThrill",
    "#GamingAdventures",
    "#GamingQuest",
    "#GamingChallenge",
    "#GamingCompetition",
    "#GamingTournament",
    "#GamingPrize",
    "#GamingReward",
    "#GamingAchievement",
    "#GamingProgress",
    "#GamingImprovement",
    "#GamingTips",
    "#GamingTricks",
    "#GamingHacks",
    "#GamingStrategies",
    "#GamingCommunitySupport"
]




# Assign IDs to forums and topics
forums = list(zip(foro_ids, forum_names))
topics = list(zip(topic_ids, topic_names))
users = list(zip(users_ids, usernames))


# Open a file to write the SQL insert statements
# Open a file to write the SQL insert statements
with open('inserts.sql', 'w') as f:
    # Generate messages and insert into tables
    for message_num in range(1, 1000):  # Generate 5 messages
        timestamp = generate_random_date()
        timestamp_unix = int(time.mktime(timestamp.timetuple()))

        date = timestamp.strftime("%Y-%m-%d")
        message_id = uuid.uuid1()  # Generate UUID v1 with the timestamp
        
        topic = random.choice(topics)
        foro = random.choice(forums)
        user = random.choice(users)
        text = f"This is message: {str(uuid.uuid4())}"
        links = [f"link{random.randint(1, 10)}" for _ in range(random.randint(0, 3))]
        num_hashtags = random.randint(1, 5)
        message_hashtags = random.sample(hashtags, num_hashtags)

        topic_id = topic[0]
        foro_id = foro[0]
        user_name = user[1]
        foro_name = foro[1]
        topic_name = topic[1]

        # Insert into messages_by_id table
        f.write(f"INSERT INTO messages_by_id (message_id, date, topic_id, foro_id, user_name, texto, links, hashtags) VALUES ({message_id}, '{date}', {topic_id}, {foro_id}, '{user_name}', '{text}', {json.dumps(links)}, {json.dumps(message_hashtags)});\n\n")

        # Insert into messages_by_topic table
        f.write(f"INSERT INTO messages_by_topic (topic_id, date, message_id, foro_id, foro_name, user_name, texto, links, hashtags) VALUES ({topic_id}, '{date}', {message_id}, {foro_id}, '{foro_name}', '{user_name}', '{text}', {json.dumps(links)}, {json.dumps(message_hashtags)});\n\n")

        # Insert into messages_by_foro table
        f.write(f"INSERT INTO messages_by_foro (foro_id, date, message_id, topic_id, topic_name, user_name, texto, links, hashtags) VALUES ({foro_id}, '{date}', {message_id}, {topic_id}, '{topic_name}', '{user_name}', '{text}', {json.dumps(links)}, {json.dumps(message_hashtags)});\n\n")


file_path = 'inserts.sql' 
replace_quotes(file_path)

data = {
    "forums": [
        {"id": forum[0], "name": forum[1]} for forum in forums
    ],
    "topics": [
        {"id": topic[0], "name": topic[1]} for topic in topics
    ],
    "users": [
        {"id": user[0], "name": user[1]} for user in users
    ]
}

# Save the data to a JSON file
with open('data.json', 'w') as f:
    json.dump(data, f, indent=4)
