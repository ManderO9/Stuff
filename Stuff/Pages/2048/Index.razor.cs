using Microsoft.AspNetCore.Components;
using System.Security.Cryptography;

namespace Stuff.Pages._2048
{
    public partial class Index
    {
        #region Public Properties

        /// <summary>
        /// The input element to get the user keyboard input
        /// </summary>
        public ElementReference KeyboardReader { get; set; }

        #endregion

        #region On After Render

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                // Focus the main div
                await KeyboardReader.FocusAsync();
            await base.OnAfterRenderAsync(firstRender);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// The list of grid elements we have in the game
        /// </summary>
        private GridItem[] mGridItems = new GridItem[16];

        /// <summary>
        /// The random number generator for the game
        /// </summary>
        private Random mRandom = new();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Index()
        {
            // Initialize the grid
            InitializeGrid();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Returns the index in the array for a given row and column
        /// </summary>
        /// <param name = "row">The row to get the index for</param>
        /// <param name = "col">The column to get the index for</param>
        /// <returns></returns>
        private int GetIndex(int row, int col) => row * 4 + col;

        /// <summary>
        /// Initializes the grid with empty elements with two elements that are not empty
        /// </summary>
        private void InitializeGrid()
        {
            // Initialize the grid with empty elements
            for (int row = 0; row < 4; row++)
                for (int col = 0; col < 4; col++)
                    mGridItems[GetIndex(row, col)] = new(int.MinValue, row, col);
            // Initially create two elements in the grid
            AddRandomGridItem(2);
            AddRandomGridItem(2);
        }

        /// <summary>
        /// Adds a new grid item to the grid with a random position
        /// </summary>
        /// <param name = "value">The value of the item to add</param>
        /// <returns>True if the item has been added, false if not</returns>
        private bool AddRandomGridItem(int value)
        {
            // If the list is full
            if (mGridItems.Where(x => x.Populated).Count() == 16)
                // Don't add the item
                return false;

            // Create a random position
            var (row, column) = (mRandom.Next(0, 4), mRandom.Next(0, 4));

            // While the position already exists in the list of grid items
            while (mGridItems[GetIndex(row, column)].Populated)
                // Create a new one
                (row, column) = (mRandom.Next(0, 4), mRandom.Next(0, 4));

            // Add the item to the list of items
            mGridItems[GetIndex(row, column)].Populated = true;
            mGridItems[GetIndex(row, column)].Value = value;

            // Return true indicating we have added the item
            return true;
        }

        /// <summary>
        /// Returns a string representing the RGB color depending on the passed in value
        /// </summary>
        /// <param name = "value">The value to get the color for</param>
        /// <returns></returns>
        private string GetColor(int value)
        {
            // Switch the log of the value
            switch (Math.Log2(value))
            {
                // Return the corresponding color
                case 1: return "#FFFF00";
                case 2: return "#ffd1b5";
                case 3: return "#eda77b";
                case 4: return "#f07e37";
                case 5: return "#de4116";
                case 6: return "#f72828";
                case 7: return "#f51414";
                case 8: return "#b50b0b";
                case 9: return "#c91054";
                case 10: return "#7d0a34";

                // If nothing works, return blue
                default: return "#0000ff";
            }


        }

        #endregion

        #region Private Classes

        /// <summary>
        /// The position of a grid item in the grid
        /// </summary>
        private class Position
        {
            /// <summary>
            /// The position from the top
            /// </summary>
            public int Row;

            /// <summary>
            /// The position from the left
            /// </summary>
            public int Column;

            /// <summary>
            /// Default constructor
            /// </summary>
            /// <param name = "column">The position from the left</param>
            /// <param name = "row">The position from the top</param>
            public Position(int column, int row)
            {
                // Set public properties
                Row = row;
                Column = column;
            }
        }

        /// <summary>
        /// The item we can have in a grid
        /// </summary>
        private class GridItem
        {
            /// <summary>
            /// Indicates whether this grid item is populated with an item or empty
            /// </summary>
            public bool Populated { get; set; }

            /// <summary>
            /// The value of the item
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// The position of this grid item in the grid
            /// </summary>
            public Position Position { get; set; }

            /// <summary>
            /// Indicates if this element has been merged with another one during the current iteration of the game
            /// </summary>
            public bool AlreadyMerged;

            /// <summary>
            /// Default constructor
            /// </summary>
            /// <param name = "value">The value of the grid item to create</param>
            /// <param name = "row">The row position of the item to create</param>
            /// <param name = "column">The column position of the item to create</param>
            /// <param name = "populated">Whether this grid item is visible and has a value or not</param>
            public GridItem(int value, int row, int column, bool populated = false)
            {
                Populated = populated;
                Value = value;
                Position = new(column, row);
            }
        }

        #endregion

        #region On Key Press

        /// <summary>
        /// Gets called when a key gets pressed
        /// </summary>
        private async Task KeyPressed(string key)
        {
            // Whether the key that has been pressed is a valid key press(up, top, left and right arrow) or not
            var validMove = true;

            // Switch the pressed key
            switch (key)
            {
                // If we pressed the up arrow
                case "ArrowUp":
                // Or the w key
                case "w":
                    // Call the swipe up handler
                    SwipeUp();

                    // Break
                    break;

                // If we pressed the down arrow
                case "ArrowDown":
                // Or the s key
                case "s":
                    // Call the swipe down handler
                    SwipeDown();

                    // Break
                    break;

                // If we pressed the left arrow
                case "ArrowLeft":
                // Or the a key
                case "a":
                    // Call the swipe left handler
                    SwipeLeft();

                    // Break
                    break;

                // If we pressed the right arrow
                case "ArrowRight":
                // Or the d key
                case "d":
                    // Call the swipe right handler
                    SwipeRight();

                    // Break
                    break;

                // Otherwise...
                default:
                    // Set valid move to false, meaning the key that we pressed was not a valid play
                    validMove = false;
                    // Break
                    break;
            }

            // If the user did a valid move
            if (validMove)
            {
                // Await a certain delay
                await Task.Delay(100);

                // Add a new item to the grid
                AddRandomGridItem(2);
            }
        }

        #endregion


        #region Action Handlers

        /// <summary>
        /// Takes the position of an element, moves it to the left if it's not the first one to the left,
        /// and it has an unpopulated item to it's left or has another item with the same value to it's left,
        /// so it merges the two together
        /// </summary>
        /// <param name="position">The position of the element to move to the left</param>
        /// <returns>True if the element has been moved, false if not</returns>
        private bool GoLeft(Position position)
        {
            // Get the current element
            var current = mGridItems[GetIndex(position.Row, position.Column)];

            // If we are in the first column, or the element is not populated we are not gonna go left
            if (position.Column == 0 || !current.Populated)
                // Return false indicating we didn't change the position
                return false;

            // Otherwise...

            // Get the element to the left
            var left = mGridItems[GetIndex(position.Row, position.Column - 1)];

            // If the element to the left is populated
            if (left.Populated)
            {
                // If it has the same value as the current element and none of the elements have been already merged
                if (left.Value == current.Value && !left.AlreadyMerged && !current.AlreadyMerged)
                {
                    // Merge the current element with the one to the left ...
                    // Give the left element double it's value
                    left.Value *= 2;

                    // Set the left element merged to true
                    left.AlreadyMerged = true;

                    // Set the current element to not populated
                    current.Populated = false;

                    // Return indicating we have changed the position of the element
                    return true;
                }
                // Otherwise, if the left element is populated but already merged or doesn't have the same value as the current element
                else
                {
                    // Return false indicating we have not changed the position
                    return false;
                }
            }
            // Otherwise, the left element is not populated
            else
            {
                // Move the element to the left

                // Set the new values
                left.Value = current.Value;

                // Set the left element populated to true
                left.Populated = true;

                // Set the current element populated to false
                current.Populated = false;

                // Return true indicated we have changed the position
                return true;
            }

        }

        /// <summary>
        /// Takes the position of an element, moves it to the right if it's not the last one to the right,
        /// and it has an unpopulated item to it's right or has another item with the same value to it's right,
        /// so it merges the two together
        /// </summary>
        /// <param name="position">The position of the element to move to the right</param>
        /// <returns>True if the element has been moved, false if not</returns>
        private bool GoRight(Position position)
        {
            // Get the current element
            var current = mGridItems[GetIndex(position.Row, position.Column)];

            // If we are in the last column, or the element is not populated we are not gonna go right
            if (position.Column == 3 || !current.Populated)
                // Return false indicating we didn't change the position
                return false;

            // Otherwise...

            // Get the element to the right
            var right = mGridItems[GetIndex(position.Row, position.Column + 1)];

            // If the element to the right is populated
            if (right.Populated)
            {
                // If it has the same value as the current element and none of the elements have been already merged
                if (right.Value == current.Value && !right.AlreadyMerged && !current.AlreadyMerged)
                {
                    // Merge the current element with the one to the right ...
                    // Give the right element double it's value
                    right.Value *= 2;

                    // Set the right element merged to true
                    right.AlreadyMerged = true;

                    // Set the current element to not populated
                    current.Populated = false;

                    // Return indicating we have changed the position of the element
                    return true;
                }
                // Otherwise, if the right element is populated but already merged or doesn't have the same value as the current element
                else
                {
                    // Return false indicating we have not changed the position
                    return false;
                }
            }
            // Otherwise, the right element is not populated
            else
            {
                // Move the element to the right

                // Set the new values
                right.Value = current.Value;

                // Set the right element populated to true
                right.Populated = true;

                // Set the current element populated to false
                current.Populated = false;

                // Return true indicated we have changed the position
                return true;
            }

        }

        /// <summary>
        /// Takes the position of an element, moves it to the bottom if it's not the last one to the bottom,
        /// and it has an unpopulated item below it or has another item with the same value below it, so it merges the two together
        /// </summary>
        /// <param name="position">The position of the element to move to the bottom</param>
        /// <returns>True if the element has been moved, false if not</returns>
        private bool GoDown(Position position)
        {

            // Get the current element
            var current = mGridItems[GetIndex(position.Row, position.Column)];

            // If we are in the last row, or the element is not populated we are not gonna go down
            if (position.Row == 3 || !current.Populated)
                // Return false indicating we didn't change the position
                return false;

            // Otherwise...

            // Get the element below
            var below = mGridItems[GetIndex(position.Row + 1, position.Column)];

            // If the element below is populated
            if (below.Populated)
            {
                // If it has the same value as the current element and none of the elements have been already merged
                if (below.Value == current.Value && !below.AlreadyMerged && !current.AlreadyMerged)
                {
                    // Merge the current element with the below one...
                    // Give the below element double it's value
                    below.Value *= 2;

                    // Set the below element merged to true
                    below.AlreadyMerged = true;

                    // Set the current element to not populated
                    current.Populated = false;

                    // Return indicating we have changed the position of the element
                    return true;
                }
                // Otherwise, if the below is populated but already merged or doesn't have the same value as the current element
                else
                {
                    // Return false indicating we have not changed the position
                    return false;
                }
            }
            // Otherwise, the below element is not populated
            else
            {
                // Move the element to the bottom

                // Set the new values
                below.Value = current.Value;

                // Set the below element populated to true
                below.Populated = true;

                // Set the current element populated to false
                current.Populated = false;

                // Return true indicated we have changed the position
                return true;

            }
        }

        /// <summary>
        /// Takes the position of an element, moves it up if it's not the first one to the top,
        /// and it has an unpopulated item above it or has another item with the same value above it, so it merges the two together
        /// </summary>
        /// <param name="position">The position of the element to move to the top</param>
        /// <returns>True if the element has been moved, false if not</returns>
        private bool GoUp(Position position)
        {
            // Get the current element
            var current = mGridItems[GetIndex(position.Row, position.Column)];

            // If we are in the first row, or the element is not populated we are not gonna go up
            if (position.Row == 0 || !current.Populated)
                // Return false indicating we didn't change the position
                return false;

            // Otherwise...

            // Get the element above
            var top = mGridItems[GetIndex(position.Row - 1, position.Column)];

            // If the element above is populated
            if (top.Populated)
            {
                // If it has the same value as the current element and none of the elements have been already merged
                if (top.Value == current.Value && !top.AlreadyMerged && !current.AlreadyMerged)
                {
                    // Merge the current element with the top one...
                    // Give the top element double it's value
                    top.Value *= 2;

                    // Set the top element merged to true
                    top.AlreadyMerged = true;

                    // Set the current element to not populated
                    current.Populated = false;

                    // Return indicating we have changed the position of the element
                    return true;
                }
                // Otherwise, if the top is populated but already merged or doesn't have the same value as the current element
                else
                {
                    // Return false indicating we have not changed the position
                    return false;
                }
            }
            // Otherwise, the top element is not populated
            else
            {
                // Move the element to the top

                // Set the new values
                top.Value = current.Value;

                // Set the top element populated to true
                top.Populated = true;

                // Set the current element populated to false
                current.Populated = false;

                // Return true indicated we have changed the position
                return true;
            }
        }


        /// <summary>
        /// Swipes the elements to the top
        /// </summary>
        private void SwipeUp()
        {
            // For each row
            for (var row = 0; row < 4; row++)
            {
                // For each column
                for (var col = 0; col < 4; col++)
                {
                    // Get the position of the current element
                    var position = new Position(row, col);

                    // While we still can go up for the current element
                    while (GoUp(position))
                        // Go up and change the row position for the element
                        position.Row--;
                }
            }

            // For all the items
            for (var i = 0; i < 16; i++)
            {
                // Set the merged flag to false
                mGridItems[i].AlreadyMerged = false;
            }
        }

        /// <summary>
        /// Swipes the elements down
        /// </summary>
        private void SwipeDown()
        {
            // For each row
            for (var row = 3; row >= 0; row--)
            {
                // For each column
                for (var col = 3; col >= 0; col--)
                {
                    // Get the position of the current element
                    var position = new Position(row, col);

                    // While we still can go down for the current element
                    while (GoDown(position))
                        // Go down and change the row position for the element
                        position.Row++;
                }
            }

            // For all the items
            for (var i = 0; i < 16; i++)
            {
                // Set the merged flag to false
                mGridItems[i].AlreadyMerged = false;
            }
        }

        /// <summary>
        /// Swipes all the elements to the left
        /// </summary>
        private void SwipeLeft()
        {
            // For each column
            for (var col = 0; col < 4; col++)
            {
                // For each row
                for (var row = 0; row < 4; row++)
                {
                    // Get the position of the current element
                    var position = new Position(row, col);

                    // While we still can go left for the current element
                    while (GoLeft(position))
                        // Go left and change the column position for the element
                        position.Column--;
                }
            }

            // For all the items
            for (var i = 0; i < 16; i++)
            {
                // Set the merged flag to false
                mGridItems[i].AlreadyMerged = false;
            }
        }

        /// <summary>
        /// Swipe the elements to the right
        /// </summary>
        private void SwipeRight()
        {
            // For each column
            for (var col = 3; col >= 0; col--)
            {
                // For each row
                for (var row = 3; row >= 0; row--)
                {
                    // Get the position of the current element
                    var position = new Position(row, col);

                    // While we still can go right for the current element
                    while (GoRight(position))
                        // Go right and change the column position for the element
                        position.Column++;
                }
            }

            // For all the items
            for (var i = 0; i < 16; i++)
            {
                // Set the merged flag to false
                mGridItems[i].AlreadyMerged = false;
            }

        }

        #endregion
    }
}