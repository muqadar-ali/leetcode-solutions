/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode BstFromPreorder(int[] preorder) {
        TreeNode head=null;
        for(int i=0;i<preorder.Length;++i){
            InsertBst(ref head, preorder[i]);
        }
        
        return head;
    }
    
    public void InsertBst(ref TreeNode head,int i){
        TreeNode curr=head;
        
        // first entry
        if(curr==null){
            Console.WriteLine("first: "+i);
            head = new TreeNode(i,null,null);  
        }
        else
        {
            if(i < curr.val){
                InsertBst(ref curr.left,i);
                
            }else {
                InsertBst(ref curr.right,i);
            } 
        }
    }
}