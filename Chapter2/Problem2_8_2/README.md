# Poker Hands

This problem can be found [here](https://onlinejudge.org/index.php?option=com_onlinejudge&Itemid=8&category=30&page=show_problem&problem=1256)

# Discussion

This is a pretty fun problem to do, and it really gives a chance to think about how to use pattern matching to do it.  
Doing the traditional solution before pattern matching would not be substantially different but the way to do it in 
modern C# is very nice.

For example, see the HandRanker.  This is the class that decides which ranking of hand you have (Straight flush, etc.).
In the past, we'd look for various patterns using things like counting cards of each rank, etc. and looking for patterns
in the array of results.  For instance, you could make an array with 15 elements and increment the element for each
card you see to see how many of each card you have.  Then you could do some sort of score or something to make a strong
ordering of the hands.  For instance, the hand types could have a number from 1 to 9 (as I did), and you could have
a rule for how to build the score up doing something like `<hand rank> * 10000 + <hand score>` where the hand score 
portion of that is dependent on the hand type.  For instance, 3 of a kind would use the highest card value, followed by
the values of the other two cards with some scaling (`<hand score> = 15^2 * (one of 3) + 15 * highest + lowest`).

However, since we have pattern matching and inheritance / abstract classes we can do this much easier.  For instance:
1. Identify if we have a flush by looking for all cards of the same suit (distinct suit count = 1)
2. Identify the groups of matching cards, in descending order by match count and rank and split into two arrays (two 
   pair 7s over 3s with a 5 will be groups of `[2, 2, 1]` with ranks of `[7, 3, 5]`)
3. Match up the different rules using these two arrays and the isFlush flag to tell us which hand we have.
4. If we don't match one of the known hands, we have a `HighCard` ranked hand.

For example, the pattern matching rule for a 3 of a kind is:
```
    // three of a kind
    ([3, 1, 1], _) => new ThreeOfAKind(groups[0].ToArray(), groups.Skip(1).SelectMany(x => x).ToArray()),
```
where the [3, 1, 1] is because we aren't a full house (that would be [3,2]) and the parameters to the `ThreeOfAKind`
class are the 3 matching cards (first parameter) and the remaining cards (other two groups) as the second parameter.

This makes the code very easy to write, test, and understand once you know pattern matching.
