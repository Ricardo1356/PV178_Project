import random
import json
import os

TEAMS = ["Pittsburgh-Penguins-PIT", "Edmonton-Oilers-EDM", "New York-Rangers-NYR", "Carolina-Hurricanes-CAR",
         "Boston-Bruins-BOS", "Dallas-Stars-DAL", "Los Angeles-Kings-LAK", "Arizona-Coyotes-ARI", "Buffalo-Sabres-BUF",
         "Calgary-Flames-CGY", "Chicago-Blackhawks-CHI", "Colorado-Avalanche-COL", "Columbus-Blue Jackets-CBJ",
         "Detroit-Red Wings-DET", "Florida-Panthers-FLA", "Minnesota-Wild-MIN", "Montreal-Canadiens-MTL",
         "Nashville-Predators-NSH", "New Jersey-Devils-NJD", "New York-Islanders-NYI", "Ottawa-Senators-OTT",
         "Philadelphia-Flyers-PHI", "San Jose-Sharks-SJS", "St. Louis-Blues-STL", "Tampa Bay-Lightning-TBL",
         "Toronto-Maple Leaves-TOR", "Vancouver-Canucks-VAN", "Vegas-Golden Knights-VGK", "Washington-Capitals-WSH",
         "Winnipeg-Jets-WPG"]

FIRST_NAMES = ["John", "Thomas", "James", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Charles",
               "Daniel", "Matthew", "Anthony", "Mark", "Paul", "Steven", "Andrew", "Kenneth", "Joshua", "Kevin",
               "Brian", "Edward", "Ronald", "Timothy", "Jason", "Jeffrey", "Ryan", "Gary", "Nicholas", "Eric",
               "Stephen", "Jacob", "Larry", "Frank", "Scott", "Justin", "Brandon", "Raymond", "Gregory", "Samuel",
               "Benjamin", "Patrick", "Jack"]

LAST_NAMES = ["Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor",
              "McDonald", "Harris", "Clark", "Lewis", "Young", "King", "Scott", "Green", "Baker", "Adams", "Nelson",
              "Hill", "Ramirez", "Reed", "Cook", "Morgan", "Bell", "Murphy", "Bailey", "Rivera", "Cooper", "Richardson",
              "Peterson", "Gray", "Rogers", "Bryant", "Russell", "Griffin", "Diaz", "Hayes", "Myers", "Ford",
              "Hamilton", "Graham", "Clayton", "Kim", "Hernandez", "Hart", "Hawkins", "Spencer", "Gibson", "Wallace"]

COLORS = {
    "PIT": [
        [0, 0, 0],
        [207, 196, 147],
        [252, 181, 20]
    ],
    "EDM": [
        [4, 30, 66],
        [252, 76, 2],
        [4, 30, 66]
    ],
    "NYR": [
        [0, 56, 168],
        [206, 17, 38],
        [255, 255, 255]
    ],
    "CAR": [
        [206, 17, 38],
        [255, 255, 255],
        [164, 169, 173]
    ],
    "BOS": [
        [0, 0, 0],
        [252, 181, 20],
        [0, 0, 0]
    ],
    "DAL": [
        [0, 104, 71],
        [143, 143, 140],
        [17, 17, 17]
    ],
    "LAK": [
        [17, 17, 17],
        [162, 170, 173],
        [255, 255, 255]
    ],
    "ARI": [
        [140, 38, 51],
        [226, 214, 181],
        [17, 17, 17]
    ],
    "BUF": [
        [0, 48, 135],
        [255, 184, 28],
        [255, 255, 255]
    ],
    "CGY": [
        [210, 0, 28],
        [250, 175, 25],
        [255, 255, 255]
    ],
    "CHI": [
        [207, 10, 44],
        [255, 255, 255],
        [0, 0, 0]
    ],
    "COL": [
        [111, 38, 61],
        [35, 97, 146],
        [162, 170, 173]
    ],
    "CBJ": [
        [0, 38, 84],
        [206, 17, 38],
        [164, 169, 173]
    ],
    "DET": [
        [206, 17, 38],
        [255, 255, 255],
        [206, 17, 38]
    ],
    "FLA": [
        [4, 30, 66],
        [200, 16, 46],
        [185, 151, 91]
    ],
    "MIN": [
        [175, 35, 36],
        [237, 170, 0],
        [2, 73, 48]
    ],
    "NSH": [
        [24, 30, 66],
        [255, 184, 28],
        [255, 255, 255]
    ],
    "NJD": [
        [0, 0, 0],
        [206, 17, 38],
        [255, 255, 255]
    ],
    "NYI": [
        [0, 83, 155],
        [244, 125, 48],
        [0, 83, 155]
    ],
    "OTT": [
        [0, 0, 0],
        [218, 26, 50],
        [183, 146, 87],
    ],
    "PHI": [
        [0, 0, 0],
        [247, 73, 2],
        [255, 255, 255]
    ],
    "SJS": [
        [0, 109, 117],
        [236, 119, 34],
        [0, 0, 0]
    ],
    "STL": [
        [0, 47, 135],
        [252, 181, 20],
        [4, 30, 66]
    ],
    "TBL": [
        [0, 40, 104],
        [255, 255, 255],
        [0, 40, 104]
    ],
    "TOR": [
        [0, 32, 91],
        [255, 255, 255],
        [0, 32, 91]
    ],
    "VAN": [
        [0, 32, 91],
        [10, 134, 61],
        [4, 28, 44]
    ],
    "VGK": [
        [51, 63, 72],
        [185, 151, 91],
        [153, 153, 153]
    ],
    "WSH": [
        [4, 30, 66],
        [200, 16, 46],
        [255, 255, 255]
    ],
    "WPG": [
        [4, 30, 66],
        [0, 76, 151],
        [255, 255, 255]
    ]
}

for team_abbr, colors in COLORS.items():
    COLORS[team_abbr] = [[255] + color for color in colors]

POSITIONS = ["C", "LW", "RW", "D"]


# PUT YOUR PATH HERE
path = ""


def generate_players(num_players):
    """Generates a list of players with random attributes."""
    return [
        {
            "Name": f"{random.choice(FIRST_NAMES)} {random.choice(LAST_NAMES)}",
            "Age": random.randint(18, 40),
            "Height": random.randint(150, 200),
            "Weight": random.randint(60, 120),
            "Position": random.choice(POSITIONS)
        } for _ in range(num_players)
    ]


def generate_team_data():
    """Generates data for all teams."""
    all_teams_data = []
    for team in TEAMS:
        city, name, abbr = team.split('-')
        colors = COLORS.get(abbr, [[255, 0, 0, 0], [255, 255, 255, 255], [255, 0, 0, 0]])
        if len(colors) < 4:
            colors = colors + colors[:1]

        team_data = {
            "Name": name,
            "City": city,
            "Colors": {
                "TopColor": colors[0],
                "BackGroundColor": colors[1],
                "BottomColor": colors[2]
            },
            "Abbreviation": abbr,
            "Players": generate_players(10)
        }
        all_teams_data.append(team_data)
    return all_teams_data


def save_data(all_teams_data):
    """Saves all generated data to files."""
    os.makedirs(path, exist_ok=True)

    # Directories for the files
    team_files_path = os.path.join(path, 'TeamFiles')
    players_files_path = os.path.join(path, 'PlayerFiles')
    os.makedirs(team_files_path, exist_ok=True)
    os.makedirs(players_files_path, exist_ok=True)

    # Save the SampleTeams.json
    with open(os.path.join(path, 'SampleTeams.json'), 'w') as f:
        json.dump(all_teams_data, f, indent=4)

    # Save individual team files
    for team_data in all_teams_data:
        with open(os.path.join(team_files_path, f'Team_{team_data["Abbreviation"]}.json'), 'w') as f:
            json.dump(team_data, f, indent=4)

    # Save player batches
    for i in range(10):
        players_batch = [player for team in all_teams_data for player in team["Players"][i::10]]
        with open(os.path.join(players_files_path, f'Players_{i}.json'), 'w') as f:
            json.dump(players_batch, f, indent=4)


def main():
    teams_data = generate_team_data()
    save_data(teams_data)


if __name__ == '__main__':
    main()
