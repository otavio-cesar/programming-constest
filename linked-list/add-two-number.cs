namespace AddTwoNumber;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int a = l1.val;
        int b = l2.val;
        ListNode result = new((a + b) % 10);
        ListNode head = result;
        int carry = (a + b) / 10;
        while(l1.next != null || l2.next != null)
        {
            result.next = new ListNode();
            result = result.next;
            if (l2.next != null)
            {
                l2 = l2.next;
                b = l2.val;
            }
            else
            {
                b = 0;
            }
            if (l1.next != null)
            {
                l1 = l1.next;
                a = l1.val;
            }
            else
            {
                a = 0;
            }
            result.val = (a + b + carry) % 10;
            carry = (a + b + carry) / 10;
        }
        if(carry > 0)
        {
            result.next = new ListNode(carry);
        }
        return head;
    }
}

public partial class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

         // Input: l1 = [2,4,3], l2 = [5,6,4]
        // Output: [7,0,8]
        // Explanation: 342 + 465 = 807.

        // Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
        // Output: [8,9,9,9,0,0,0,1]
        
        ListNode l1 = new(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));    
        ListNode l2 = new(9, new ListNode(9, new ListNode(9, new ListNode(9))));
        // ListNode l1 = new(2, new ListNode(4, new ListNode(3)));
        // ListNode l2 = new(5, new ListNode(6, new ListNode(4)));

        ListNode result = solution.AddTwoNumbers(l1, l2);

        while (result != null)
        {
            Console.WriteLine(result.val);
            result = result.next;
        }
    }
}