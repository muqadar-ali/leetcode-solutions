/**
* You are given two non-empty linked lists representing two non-negative integers. 
* The digits are stored in reverse order, and each of their nodes contains a single digit. 
* Add the two numbers and return the sum as a linked list.
* You may assume the two numbers do not contain any leading zero, except the number 0 itself.
* Example 1:
*           2 -> 4 -> 3
*           5 -> 6 -> 4
*          ==============
*           7 -> 0 -> 8
* Input: l1 = [2,4,3], l2 = [5,6,4]
* Output: [7,0,8]
* Explanation: 342 + 465 = 807.
*
*
* Example 2:
* Input: l1 = [0], l2 = [0]
* Output: [0]
*
*
* Example 3:
* Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
* Output: [8,9,9,9,0,0,0,1]
*
*
*
* Constraints:
*   * The number of nodes in each linked list is in the range [1, 100].
*   * 0 <= Node.val <= 9
*   * It is guaranteed that the list represents a number that does not have leading zeros.
*
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        
        var lInt1=LinkedListToListInt(l1);
        var lInt2=LinkedListToListInt(l2);
        
        bool isList1Small = lInt1?.Count < lInt2?.Count;
        int diff = Math.Abs(lInt1.Count - lInt2.Count);
        // add zeroes in list
        for(int i=diff; i>0;--i){
            if(isList1Small){
                lInt1.Insert(0,0);
            }
            else{
                lInt2.Insert(0,0);
            }
        }
        // now both lists should be equal, calculate result
        string result = "";
        int propagate = 0; // this is the value that needs to be added in next number
        for(int i=lInt1.Count-1;i>=0;--i){
            int sum= lInt1[i]+lInt2[i]+propagate;
            propagate = sum/10;
            if(sum > 9){
                result+=$"{sum%10}";
            }
            else{
                
                result+=$"{sum}";
            }
        }
        if(propagate>0)
            result+=$"{propagate}";
                
        return StrToLinkedList(result);
    }
    
     // covert linked list to list<int>
    public List<int> LinkedListToListInt(ListNode l){
        List<int> numbers = new List<int>();
        while(l!=null){
            numbers.Insert(0,l.val);
            l=l.next;      
        }
        return numbers;
    }
    
    // convert final number (e.g. 807) to list ([7,0,8])
    public ListNode StrToLinkedList(string s){
        
        ListNode head=new ListNode(0,null);
        ListNode curr=head;
        for(int i=0; i<s.Length;++i){
            
                curr.val=int.Parse(s[i].ToString());
                // do not populate next after last index
                if(i<s.Length-1){
                  curr.next=new ListNode(0,null);
                  curr=curr.next;  
                }
                
        }
        return head;
    }
}
