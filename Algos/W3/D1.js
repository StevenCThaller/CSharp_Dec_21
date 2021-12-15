/**
 * Class to represent a Node in a Binary Search Tree (BST).
 */
class Node {
    /**
     * Constructs a new instance of a BST node.
     * @param {number} data The integer to store in the node.
     */
    constructor(data) {
        this.data = data;
        /**
         * These properties are how this node is connected to other nodes to form
         * the tree. Similar to .next in a SinglyLinkedList except a BST node can
         * be connected to two other nodes. To start, new nodes will not be
         * connected to any other nodes, these properties will be set after
         * the new node is instantiated.
         */
        this.left = null;
        this.right = null;
    }
}

/**
 * Represents an ordered tree of nodes where the data of left nodes are <= to
 * their parent and the data of nodes to the right are > their parent's data.
 */
class BinarySearchTree {
    constructor() {
        /**
         * Just like the head of a linked list, this is the start of our tree which
         * branches downward from here.
         */
        this.root = null;
    }

    // Logs this tree horizontally with the root on the left.
    print(node = this.root, spaceCnt = 0, spaceIncr = 10) {
        if (!node) {
            return;
        }

        spaceCnt += spaceIncr;
        this.print(node.right, spaceCnt);

        console.log(
            " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
            `${node.data}`
        );

        this.print(node.left, spaceCnt);
    }

    /**
     * Determines if this tree is empty.
     * - Time: O(1) - Constant.
     * - Space: O(1) - Constant.
     * @returns {boolean} Indicates if this tree is empty.
     */
    isEmpty() { 
        return this.root === null;
    }

    /**
     * Retrieves the smallest integer data from this tree.
     * - Time: O(h) - Linear in relation to the height of the tree.
     * - Space: O(1) - Constant.
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The smallest integer from this tree.
     */
    min(current = this.root) { 
        // Edge Case: Empty tree
        if(!current) {
            return null;
        }
        // Finding the smallest is just going to the left as much as you can
        while(current.left) {
            current = current.left;
        }

        return current.data;
        
    }

    /**
     * Retrieves the largest integer data from this tree.
     * - Time: O(h) - Linear in relation to the height of the tree.
     * - Space: O(1) - Constant.
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The largest integer from this tree.
     */
    max(current = this.root) { 
        // This is going to be identical to min, but to the right
        if(!current) {
            return null;
        }

        while(current.right) {
            current = current.right;
        }

        return current.data;
    }

    // Bonus Challenges
    /**
     * Retrieves the smallest integer data from this tree.
     * - Time: O(h) - Linear with relation to the height of the tree.
     * - Space: O(h) - Linear with relation to the height of the tree.
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The smallest integer from this tree.
     */
    minRecursive(current = this.root) { 
        if(!current) {
            return null;
        } else if(!current.left) {
            return current.data;
        } else {
            return this.minRecursive(current.left);
        }
    }

    /**
     * Retrieves the largest integer data from this tree.
     * - Time: O(h) - Linear with relation to the height of the tree.
     * - Space: O(h) - Linear with relation to the height of the tree.
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The largest integer from this tree.
     */
    maxRecursive(current = this.root) { 
        if(!current) {
            return null;
        } else if(!current.right) {
            return current.data;
        } else {
            return this.maxRecursive(current.right);
        }
    }
}

const emptyTree = new BinarySearchTree();
const oneNodeTree = new BinarySearchTree();
oneNodeTree.root = new Node(10);

/* twoLevelTree
        root
        10
      /   \
    5     15
*/
const twoLevelTree = new BinarySearchTree();
twoLevelTree.root = new Node(10);
twoLevelTree.root.left = new Node(5);
twoLevelTree.root.right = new Node(15);

twoLevelTree.print();

/**  fullTree
 *                 root
 *              <-- 25 -->
 *            /            \
 *           15             50
 *         /    \         /    \
 *       10      22      35     70
 *      /  \    /  \    /  \   /  \
 *     4   12  18  24  31  44 66  90
 */
const fullTree = new BinarySearchTree();
fullTree.root = new Node(25);

// left sub-tree
fullTree.root.left = new Node(15);
fullTree.root.left.left = new Node(10);
fullTree.root.left.right = new Node(22);
fullTree.root.left.left.left = new Node(4);
fullTree.root.left.left.right = new Node(12);
fullTree.root.left.right.left = new Node(18);
fullTree.root.left.right.right = new Node(24);

// right sub-tree
fullTree.root.right = new Node(50);
fullTree.root.right.left = new Node(35);
fullTree.root.right.right = new Node(70);
fullTree.root.right.left.left = new Node(31);
fullTree.root.right.left.right = new Node(44);
fullTree.root.right.right.left = new Node(66);
fullTree.root.right.right.right = new Node(90);