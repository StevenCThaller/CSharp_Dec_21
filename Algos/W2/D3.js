class LinkedListStack {
    constructor() {
        this.head = null;
        this.length = 0;
    }

    /**
     * Adds a new given item to the top / back of this stack.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @param {any} item The new item to be added to the top / back.
     * @returns {number} The new length of this stack.
     */
    push(item) { 
        let newTopOfStack = new Node(item);

        newTopOfStack.next = this.head;
        this.head = newTopOfStack;
        this.length++;
        return this.length;
    }

    /**
     * Removes the top / last item from this stack.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {any} The removed item or null if this stack was empty.
     */
    pop() { 
        if(this.isEmpty()) {
            return null;
        }

        let removedItem = this.head;
        this.head = removedItem.next;
        this.length--;
        return removedItem.data;
    }

    /**
     * Retrieves the top / last item from this stack without removing it.
     * - Time: O(1) - Linear
     * - Space: O(1) - Constant
     * @returns {any} The top / last item of this stack or null if empty.
     */
    peek() { 
        return this.head ? this.head.data : null; // OH HOW FANCY
    }

    /**
     * Returns whether or not this stack is empty.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {boolean}
     */
    isEmpty() { 
        return this.head == null;
    }

    /**
     * Returns the size of this stack.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {number} The length.
     */
    size() { 
        return this.length;
    }
}


class Node {
    constructor(value) {
        this.data = value;
        this.next = null;
    }
}

/**
 * Class to represent a queue using a Linked List to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class LinkedListQueue {
    /**
     * The constructor is executed when instantiating a new LinkedListQueue() to construct
     * a new instance.
     * @returns {Queue} This new LinkedListQueue instance is returned without having to
     *    explicitly write 'return' (implicit return).
     */
    constructor() {
        this.head = null;
        // To cut down on time complexity, we can add 2 new properties:
        this.tail = null;
        this.length = 0;
    }

    /**
     * Adds a new given item to the back of the queue and returns the new size of the queue
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @param {any} item - The item to be added to the back of the queue
     * @returns {number} The new size of the queue
     */
    enqueue(item) {
        let newItem = new Node(item);
        // EDGE CASE: Empty?
        if (this.isEmpty()) {
            this.head = newItem;
        } else {   // Since we're using a tail, let's set the tail's next node to be our newly created item
            this.tail.next = newItem;
        }
        // Then, set the tail as the new item
        this.tail = newItem;
        // And increment our length before returning it
        this.length++;
        return this.length;
    }

    /**
     * Removes the item from the front of the queue
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {any} The removed item or undefined if the queue was empty
     */
    dequeue() {
        // Edge Cases: 
        //  1. Empty queue
        //  2. Only 1 item in the queue
        if (this.isEmpty()) {
            // this is just in case somebody's been messing with our data structure
            this.length = 0;
            // and return undefined
            return undefined;
        } else if (this.length == 1) { // If the queue only contains 1 item
            // hold onto the current head
            let removed = this.head;
            // set both the head and tail to null (because removing the only item means emptying the queue)
            this.head = null;
            this.tail = null;
            // set the length to 0
            this.length = 0;
            // and return the removed item's data
            return removed.data;
        }

        // hold onto the current head before removing it
        let removed = this.head;
        // set the head to the 2nd item
        this.head = removed.next;
        // decrement our length
        this.length--;
        // remove the removed node's reference to any other item
        removed.next = null;
        // and return its data
        return removed.data;
    }

    /**
     * Returns whether or not this queue is empty
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {boolean} Whether or not the queue is empty
     */
    isEmpty() {
        return this.head == null;
    }

    /**
     * Returns the length of the queue
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {number} The length of the queue
     */
    size() {
        return this.length;
    }

    /**
     * Retrieves the item at the front of the queue without removing it.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {any} The item at the front of the queue
     */
    front() {
        // Gotta love ternary operators
        return this.head ? this.head.data : undefined;

        // The above line of code is just a shorthand for:
        if (this.head) {
            return this.head.data;
        } else {
            return undefined;
        }
    }

    /**
     * Compares this queue to another given queue to see if they are equal.
     * Avoid indexing the queue items directly via bracket notation, use the
     * queue methods instead for practice.
     * Use no extra array or objects.
     * The queues should be returned to their original order when done.
     * - Time: O(n) - Linear.
     * - Space: O(1) - Constant.
     * @param {Queue} q2 The queue to be compared against this queue.
     * @returns {boolean} Whether all the items of the two queues are equal and
     *    in the same order.
     */
    compareQueues(q2) { 
        /*
            Steps:
                1. Find the length of both this queue and q2
                2. Right away, if they're different lengths, return false
                3. Set a flag to true
                4. For each queue, one node at a time (up to the length), dequeue, 
                    compare, and enqueue again. If the data isn't the same, 
                    set our flag to false.
                5. After you've done it length number of times, it's in the
                    same order, so return the flag.
        */

        let thisLength = this.size();
        let q2Length = q2.size();

        if(thisLength != q2Length) {
            return false;
        }

        let counter = 0;
        let isTheSame = true;

        while(counter < thisLength) {
            let thisData = this.dequeue();
            let thatData = q2.dequeue();

            if(thisData != thatData) {
                isTheSame = false;
            }
            this.enqueue(thisData);
            q2.enqueue(thatData);

            counter++;
        }

        return isTheSame;
    }

    /**
     * Determines if the queue is a palindrome (same items forward and backwards).
     * Avoid indexing queue items directly via bracket notation, instead use the
     * queue methods for practice.
     * Use only 1 stack as additional storage, no other arrays or objects.
     * The queue should be returned to its original order when done.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean}
     */
    isPalindrome() { 
        /*
            Steps:
                1. Create a stack
                2. One node at a time, dequeue an item, push it to the stack,
                    then re-enqueue it, until the queue and stack have the
                    same size.
                3. At this point, the queue and stack contain the same data,
                    but in opposite orders.
                4. Until the stack is empty, pop from the stack, dequeue from the 
                    queue, compare each value, then re-enqueue (throw away the stack one).
                5. If each item from the queue and stack are equal, it's a palindrome.
        */
        // create stack
        let reverseQueue = new LinkedListStack();
        let isPal = true;

        while(reverseQueue.size() != this.size()) {
            let removedQueue = this.dequeue();
            let removedStack = reverseQueue.pop();
            if(removedQueue != removedStack) {
                isPal = false;
            }
            this.enqueue(removedQueue);
        }

        return isPal;
    }
}
