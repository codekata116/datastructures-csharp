using System;
using System.Collections.Generic;

namespace DataStructures.XYCoordinates {
	public class Edge : IEquatable<Edge>, IComparable {
		public Node StartNode { get; set; }
		public Node EndNode { get; set; }

		public double Weight {
			get {
				return Math.Sqrt(
					Math.Pow(
						StartNode.x - EndNode.x,
						2
					)
					+
					Math.Pow(
						StartNode.y - EndNode.y,
						2
					)
				);
			}
		}

		public bool Equals(
			Edge edge
		) {
			if( edge == null ) {
				return false;
			}

			return (
				this.StartNode == edge.StartNode &&
				this.EndNode == edge.EndNode
			);
		}

		public override bool Equals(
			object obj
		) {
			Edge edge = obj as Edge;
			if( edge == null ) {
				return false;
			}

			return this.Equals(
				edge
			);
		}

		public static bool operator ==(
			Edge leftEdge,
			Edge rightEdge
		) {
			return Object.Equals(
				leftEdge,
				rightEdge
			);
		}

		public static bool operator !=(
			Edge leftEdge,
			Edge rightEdge
		) {
			return !( leftEdge == rightEdge );
		}

		public override int GetHashCode() {
			int hash = 17;
			const int PRIME = 23;

			unchecked {
				hash = hash * PRIME + this.StartNode.GetHashCode();
				hash = hash * PRIME + this.EndNode.GetHashCode();
			}

			return hash;
		}

		public int CompareTo(
			object obj
		) {
			Edge edge = obj as Edge;
			if( edge == null ) {
				throw new ArgumentException(
					"Object is not an Edge object."
				);
			}

			if( this.Weight != edge.Weight ) {
				return this.Weight.CompareTo(
					edge.Weight
				);
			}

			else if (this.StartNode.x != edge.StartNode.x) {
				return this.StartNode.x.CompareTo(
					edge.StartNode.x
				);
			}

			else if( this.StartNode.y != edge.StartNode.y ) {
				return this.StartNode.y.CompareTo(
					edge.StartNode.y
				);
			}

			else if( this.EndNode.x != edge.EndNode.x ) {
				return this.EndNode.x.CompareTo(
					edge.EndNode.x
				);
			}

			else if( this.EndNode.y != edge.EndNode.y ) {
				return this.EndNode.y.CompareTo(
					edge.EndNode.y
				);
			}

			return 0;
		}

		public override string ToString() {
			return "{ nodeA = "
				+ StartNode.ToString()
				+ "; nodeB = "
				+ EndNode.ToString()
				+ "; weight = "
				+ Weight.ToString()
				+ " }"
			;
		}
	}
}
