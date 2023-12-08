namespace AdventOfCode2023;

public class Day7
{
    public static string[] ReadInput()
    {
        return File.ReadAllLines("input/day7.txt");
    }

    class Hand
    {
        public string originalHand;
        public List<Card> cards = new();
        public int bid;
        private bool part2;

        public Hand(string originalHand, string bid, bool part2 = false)
        {
            this.originalHand = originalHand;
            this.bid = int.Parse(bid);
            this.part2 = part2;
            foreach (var card in originalHand)
            {
                cards.Add(new Card(card, this.part2));
            }
        }

        public int getRank()
        {
            var numberOfJokers = cards.Where(c => c.originalValue == 'J').Count();

            if (part2 && numberOfJokers > 0)
                return getRankPart2();
            var groupedCards = cards.GroupBy(c => c.originalValue).ToList();
            var cardCounts = groupedCards.Where(c => c.Key != 'J').Select(c => c.Count()).ToList();

            if (groupedCards.Count == originalHand.Length)
            {
                return 0; // High card
            }

            if (groupedCards.Count == originalHand.Length - 1)
            {
                return 1; // One pair
            }

            if (groupedCards.Count == 3) // either two pair or Three of a kind
            {
                foreach (var cardCount in cardCounts)
                {
                    if (cardCount == 3)
                    {
                        return 3; // three of a kind
                    }
                }

                return 2; // Two pair
            }

            if (groupedCards.Count == 2) // Full house or Four of a kind
            {
                foreach (var groupedCard in groupedCards)
                {
                    if (groupedCard.Count() == 4)
                    {
                        return 5; // Four of a kind
                    }
                }

                return 4; // Full house
            }

            return 6; // Five of a kind
        }

        private int getRankPart2()
        {
            // we have more than 0 jokers
            var groupedCards = cards.GroupBy(c => c.originalValue).ToList();
            var numberOfJokers = cards.Where(c => c.originalValue == 'J').Count();
            var cardCountsWithoutJokers = groupedCards.Where(c => c.Key != 'J').Select(c => c.Count()).ToList();
            var differentCards = groupedCards.Count;
            switch (numberOfJokers)
            {
                case 1:
                    if (differentCards <= 2)
                    {
                        return 6; // Five of a kind
                    }

                    if (differentCards == 3)
                    {
                        if (cardCountsWithoutJokers.All(c => c == 2))
                        {
                            return 4; // Full house
                        }

                        if (cardCountsWithoutJokers.Contains(3))
                        {
                            return 5; // Four of a kind
                        }
                    }

                    if (differentCards == 4)
                    {
                        return 3; // three of a kind
                    }

                    if (differentCards == 5)
                    {
                        return 1;
                    }

                    break;
                case >1:
                    if (differentCards <= 2)
                        return 6; // five of a kind
                    
                    if (differentCards == 3)
                        return 5; // four of a kind
                    
                    if (differentCards == 4)
                        return 3; // three of a kind

                    break;
            }

            return 0;
        }
    }

    class Card
    {
        public int value;
        public char originalValue;

        public Card(char kind, bool part2 = false)
        {
            originalValue = kind;
            switch (kind.ToString())
            {
                case "2":
                    value = 1;
                    break;
                case "3":
                    value = 2;
                    break;
                case "4":
                    value = 3;
                    break;
                case "5":
                    value = 4;
                    break;
                case "6":
                    value = 5;
                    break;
                case "7":
                    value = 6;
                    break;
                case "8":
                    value = 7;
                    break;
                case "9":
                    value = 8;
                    break;
                case "T":
                    value = 9;
                    break;
                case "J":
                    value = part2 ? 0 : 10;
                    break;
                case "Q":
                    value = 11;
                    break;
                case "K":
                    value = 12;
                    break;
                case "A":
                    value = 13;
                    break;
            }
        }
    }

    public static void RunPart1()
    {
        var rawHands = ReadInput();
        var coolHands = new List<Hand>();
        foreach (var hand in rawHands)
        {
            var parsedHand = hand.Split(" ");
            coolHands.Add(new Hand(parsedHand[0], parsedHand[1]));
        }

        var groupedHands = coolHands.GroupBy(h => h.getRank()).ToList();
        groupedHands.Sort((a, b) => a.Key - b.Key);

        var total = 0;
        var rank = 1;
        foreach (var hands in groupedHands)
        {
            if (hands.Count() > 1)
            {
                var handsList = hands.ToList();
                handsList.Sort((a, b) =>
                {
                    for (int i = 0; i < hands.ToList()[0].cards.Count; i++)
                    {
                        if (a.cards[i].value != b.cards[i].value)
                        {
                            var diff = a.cards[i].value - b.cards[i].value;
                            return diff;
                        }
                    }

                    return 1;
                });


                foreach (var hand in handsList)
                {
                    //Console.Write(hand.bid + " * " + rank + " + ");
                    total += hand.bid * rank;
                    rank++;
                }
            }
            else
            {
                //Console.Write(hands.ToList()[0].bid + " * " + rank + " + ");
                total += rank * hands.ToList()[0].bid;
                rank++;
            }
        }

        Console.WriteLine(total);
    }

    public static void RunPart2()
    {
        var rawHands = ReadInput();
        var coolHands = new List<Hand>();
        foreach (var hand in rawHands)
        {
            var parsedHand = hand.Split(" ");
            coolHands.Add(new Hand(parsedHand[0], parsedHand[1], part2: true));
        }

        var groupedHands = coolHands.GroupBy(h => h.getRank()).ToList();
        groupedHands.Sort((a, b) => a.Key - b.Key);

        var total = 0;
        var rank = 1;
        foreach (var hands in groupedHands)
        {
            if (hands.Count() > 1)
            {
                var handsList = hands.ToList();
                handsList.Sort((a, b) =>
                {
                    for (int i = 0; i < hands.ToList()[0].cards.Count; i++)
                    {
                        if (a.cards[i].value != b.cards[i].value)
                        {
                            var diff = a.cards[i].value - b.cards[i].value;
                            return diff;
                        }
                    }

                    return 1;
                });


                foreach (var hand in handsList)
                {
                    //Console.Write(hand.bid + " * " + rank + " + ");
                    total += hand.bid * rank;
                    rank++;
                }
            }
            else
            {
                //Console.Write(hands.ToList()[0].bid + " * " + rank + " + ");
                total += rank * hands.ToList()[0].bid;
                rank++;
            }
        }

        Console.WriteLine(total);
    }
}