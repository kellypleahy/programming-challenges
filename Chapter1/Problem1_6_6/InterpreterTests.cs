using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_6;

public class InterpreterTests
{
    [Fact]
    public void Simple_halt_case()
    {
        new Interpreter([100]).Run().Should().Be(1);
    }

    [Fact]
    public void Simple_few_instructions_case()
    {
        new Interpreter([213, 323, 211, 100]).Run().Should().Be(4);
    }

    [Fact]
    public void Book_example()
    {
        new Interpreter([299, 492, 495, 399, 492, 495, 399, 283, 279, 689, 078, 100, 000, 000, 000])
            .Run()
            .Should().Be(16);
    }

    [Fact]
    public void Check_2_instructions()
    {
        new Interpreter(
            [
                204,  // r0 <- 4
                211,  // r1 <- 1
                001,  // jnz r1, r0 (pc = pc + 1 if r1 == 0, r0 otherwise)
                210,  // not executed (theoretically)
                100   // hlt
            ])
            .Run()
            .Should().Be(4);
    }

    [Fact]
    public void Check_3_instructions()
    {
        new Interpreter(
            [
                201,  // r0 <- 1
                304,  // r0 <- r0 + 4
                211,  // r1 <- 1
                001,  // jnz r1, r0 (pc = pc + 1 if r1 == 0, r0 otherwise)
                210,  // not executed (theoretically)
                100,  // hlt
            ])
            .Run()
            .Should().Be(5);
    }

    [Fact]
    public void Check_3_instructions_overflow()
    {
        new Interpreter(
            [
                209,  //0: r0 <- 9
                800,  //1: r0 <- [r0] (9) (value 999 into r0)
                307,  //2: r0 <- r0 + 7 (should be 6 after mod 1000)
                211,  //3: r1 <- 1
                001,  //4: jnz r1, r0 (should goto instruction at location 6)
                210,  //5: should not execute
                100,  //6:
                000,  //7:
                000,  //8:
                999,  //9:
            ])
            .Run()
            .Should().Be(6);
    }

    [Fact]
    public void Check_4_instructions()
    {
        new Interpreter(
            [
                201,  // r0 <- 1
                405,  // r0 <- r0 * 5
                211,  // r1 <- 1
                001,  // jnz r1, r0 (pc = pc + 1 if r1 == 0, r0 otherwise)
                210,  // not executed (theoretically)
                100,  // hlt
            ])
            .Run()
            .Should().Be(5);
    }

    [Fact]
    public void Check_4_instructions_overflow()
    {
        new Interpreter(
            [
                209,  //0: r0 <- 9
                800,  //1: r0 <- [r0] (9) (value 503 into r0)
                402,  //2: r0 <- r0 * 2 (should be 6 after mod 1000)
                211,  //3: r1 <- 1
                001,  //4: jnz r1, r0 (should goto instruction at location 6)
                210,  //5: should not execute
                100,  //6:
                000,  //7:
                000,  //8:
                503,  //9:
            ])
            .Run()
            .Should().Be(6);
    }

    [Fact]
    public void Check_5_instructions()
    {
        new Interpreter(
            [
                204,  // r0 <- 4
                510,  // r1 <- r0
                001,  // jnz r1, r0 (pc = pc + 1 if r1 == 0, r0 otherwise)
                210,  // not executed (theoretically)
                100,  // hlt
            ])
            .Run()
            .Should().Be(4);
    }

    [Fact]
    public void Check_6_instructions()
    {
        new Interpreter(
            [
                201,  // r0 <- 1
                214,  // r1 <- 4
                601,  // r0 <- r0 + r1
                001,  // jnz r1, r0 (pc = pc + 1 if r1 == 0, r0 otherwise)
                210,  // not executed (theoretically)
                100,  // hlt
            ])
            .Run()
            .Should().Be(5);
    }

    [Fact]
    public void Check_6_instructions_overflow()
    {
        new Interpreter(
            [
                209,  //0: r0 <- 9
                800,  //1: r0 <- [r0] (9) (value 999 into r0)
                217,  //2: r1 <- 7
                601,  //3: r0 <- r0 + r1 (should be 6 after mod 1000)
                001,  //4: jnz r1, r0 (should goto instruction at location 6)
                210,  //5: should not execute
                100,  //6:
                000,  //7:
                000,  //8:
                999,  //9:
            ])
            .Run()
            .Should().Be(6);
    }

    [Fact]
    public void Check_7_instructions()
    {
        new Interpreter(
            [
                201,  // r0 <- 1
                215,  // r1 <- 5
                701,  // r0 <- r0 * r1
                001,  // jnz r1, r0 (pc = pc + 1 if r1 == 0, r0 otherwise)
                210,  // not executed (theoretically)
                100,  // hlt
            ])
            .Run()
            .Should().Be(5);
    }

    [Fact]
    public void Check_7_instructions_overflow()
    {
        new Interpreter(
            [
                209,  //0: r0 <- 9
                800,  //1: r0 <- [r0] (9) (value 503 into r0)
                212,  //2: r1 <- 2
                701,  //3: r0 <- r0 * r1 (should be 6 after mod 1000)
                001,  //4: jnz r1, r0 (should goto instruction at location 6)
                210,  //5: should not execute
                100,  //6:
                000,  //7:
                000,  //8:
                503,  //9:
            ])
            .Run()
            .Should().Be(6);
    }

    [Fact]
    public void Check_8_instructions()
    {
        // this other test already confirms 8 behavior.
        Check_3_instructions_overflow();
    }

    [Fact]
    public void Check_9_instructions()
    {
        new Interpreter(
            [
                209,  //0: r0 <- 9
                800,  //1: r0 <- [r0] (9) (value 096 into r0)
                304,  //2: r0 <- r0 + 4 (value 100)
                218,  //3: r1 <- 8
                901,  //4: [r1] <- r0 (value 100 into [r1] (position 8))
                011,  //5: jnz r1, r1 (goto 8)
                210,  //6: not executed
                100,  //7: not executed
                000,  //8: will be 100 if it works right :)
                096,  //9: data
            ])
            .Run()
            .Should().Be(7);
    }

    [Fact]
    public void Check_0_instructions()
    {
        // all the tests currently use 0 instructions, so just call this for clarity.
        Check_2_instructions();
    }

}
