class Node {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class SinglyLinkedList {
    constructor() {
        this.head = null;
    }

    seedFromArr(vals) {
        for (const item of vals) {
            this.insertAtBack(item);
        }
        return this;
    }

    toArr() {
        const arr = [];
        let runner = this.head;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        return arr;
    }

    isEmpty() {
        return this.head == null;
    }

    insertAtBack(data) {
        const newNode = new Node(data);
        if (this.isEmpty()) {
            this.head = newNode;
            return this;
        }
        let runner = this.head;
        while (runner.next) {
            runner = runner.next;
        }
        runner.next = newNode;
        return this;
    }

    insertAtFront(data) {
        const newHead = new Node(data);
        newHead.next = this.head;
        this.head = newHead;

        return this;
    }

    removeHead() {
        if (this.isEmpty()) {
            return null;
        }

        const removedHead = this.head;
        this.head = removedHead.next;
        removedHead.next = null;

        return removedHead.data;

    }

    average() {
        let sum = 0;
        let count = 0;
        let runner = this.head;

        while (runner) {
            sum += runner.data;
            count++;
            runner = runner.next;
        }

        return sum / count;
    }

    removeBack() {
        if (this.isEmpty()) {
            return null;
        } else if (this.head.next == null) {
            const removed = this.head;
            this.head = null;
            return removed.data;
        } else {
            let runner = this.head;
            let walker = null;

            while (runner.next) {
                walker = runner;
                runner = runner.next;
            }

            walker.next = null;
            return runner.data;
        }
    }

    contains(val) {
        let runner = this.head;

        while (runner) {
            if (runner.data == val) return true;
            runner = runner.next;
        }
        return false;
    }

    containsRecursive(val, current = this.head) {
        if (current == null) {
            return false;
        } else if (current.data == val) {
            return true;
        } else {
            return this.containsRecursive(val, current.next);
        }
    }

    recursiveMax(runner = this.head, maxNode = this.head) {
        if (runner == null) {
            if (maxNode == null) {
                return null;
            } else {
                return maxNode.data
            }
        }

        if (runner.data > maxNode.data) {
            maxNode = runner;
        }

        return this.recursiveMax(runner.next, maxNode);
    }

    /**
     * Retrieves the data of the second to last node in this list.
     * - Time: O(n) - Linear, because the number of iterations is directly related
     *      to how many nodes are in the list.
     * - Space: O(1) - Constant, because regardless of size, we're using the same 
     *      number of variables.
     * @returns {any} The data of the second to last node or null if there is no
     *    second to last node.
     */
    secondToLast() { 
        // EDGE CASE: What if there aren't even 2 nodes?!
        if(this.isEmpty() || this.head.next == null) {
            return null;
        }

        // Now that we have that out of the way, let's take the single runner approach
        let runner = this.head;
        // The while loop should stop once the runner's .next's .next is null
        while(runner.next.next){
            runner = runner.next;
        }

        // Now runner is at the second to last node, so return its data
        return runner.data;
    }

    /**
     * Removes the node that has the matching given val as it's data.
     * - Time: O(n) - Linear relation to the number of nodes in the list.
     * - Space: O(1) - Constant: the size of the list has no impact on the amount of memory used.
     * @param {any} val The value to compare to the node's data to find the
     *    node to be removed.
     * @returns {boolean} Indicates if a node was removed or not.
     */
    removeVal(val) { 
        // EDGE CASE: What if the head has our value??
        if(this.head.data == val) {
            this.removeHead();
            return true;
        }
        // Now that that's out of the way, let's make one runner
        let runner = this.head;

        // We'll be looking not at the runner's data, but runner.next's data
        // (since we've already checked the head), so:
        while(runner.next) {
            // Ok, so if we're here, we KNOW that there is a next node.
            // Let's check that next node's data
            if(runner.next.data == val) {
                // BINGO!! Ok, now what??
                // Well, to remove that next node, we need to point runner's .next
                // at the NEXT node's .next

                // BONUS: Remove the next node's reference to ITS next node, in case we
                // want to use the node totally removed
                let removed = runner.next;
                
                runner.next = removed.next;
                // BONUS CONTINUED
                removed.next = null;

                // AND VOILA!! The node is gone!
                return true;
            }

            // Ok, so maybe this node's data doesn't match. Then what? Move on.
            runner = runner.next;
        }

        // So, you checked every single node, and never found the data, huh? Oh well.
        return false;
    }

    // EXTRA
    /**
     * Inserts a new node before a node that has the given value as its data.
     * - Time: O(n) - Linear: worst case scenario is what we use, and worst case
     *      is that the node to prepend to is the last one or doesn't exist, meaning
     *      we would check each of the n nodes once.
     * - Space: O(1) - Constant, because the amount of variables/size of the data structures
     *      declared does not change based on the size of the list.
     * @param {any} newVal The value to use for the new node that is being added.
     * @param {any} targetVal The value to use to find the node that the newVal
     *    should be inserted in front of.
     * @returns {boolean} To indicate whether the node was pre-pended or not.
     */
    prepend(newVal, targetVal) { 
        // THIS ONE IS JUICY

        // EDGE CASE: targetVal is our first node??
        if(this.head.data == targetVal) {
            // Well, prepending to the first node is just adding to the front, right? RIGHT!
            this.insertAtFront(newVal);
            return true;
        }

        /*
            Ok, back to our scheduled programming.
            If our SLL looks like THIS:
            H
            1 -> 2 -> 4 -> 5 -> 6 -> 
            And we call prepend(3,4)
            We need to make THIS:
            H
            1 -> 2 -> 4 -> 5 -> 6 -> 
            Look like THIS:
            H
            1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 

            So, similar to our removeVal, I'll be using a runner, but 
            checking its .next
        */
        let runner = this.head;

        while(runner.next) {
            // We need to check the next node's data against targetVal
            if(runner.next.data == targetVal) {
                // Well golly shucks dang, we found a match! Ok cool, now what?
                // We need to create our new node (duh)
                let newNode = new Node(newVal);

                // Assign its .next to the node we want to prepend to (aka runner.next)
                newNode.next = runner.next;

                /*
                    But, right now, our list looks something like this:
                .             3
                    H         ↓ (don't ask how I got that arrow in there)
                    1 -> 2 -> 4 -> 5 -> 6 ->
                .        r
                    We need that 2 node to point at the 3 node. Oh wait! That's our runner!
                */
                runner.next = newNode;
                /*
                    And now, our list is:
                    H
                    1 -> 2 -> 3 -> 4 -> 5 -> 6 ->
                */
                return true;
            }

            // And if the next node ISN'T supposed to be prepended to?
            runner = runner.next;
        }

        // Again, making it out of the loop means we never found our prependable node
        return false;
    }

}
