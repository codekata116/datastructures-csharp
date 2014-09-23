using System;
using System.Collections.Generic;

namespace DataStructures.XYCoordinates {
	public class Node : IEquatable<Node> {
		public int x { get; set; }
		public int y { get; set; }

		public bool Equals (
			Node node
		) {
			if( node == null ) {
				return false;
			}
			
			return (
				this.x == node.x &&
				this.y == node.y
			);
		}

		public override bool Equals( 
			Object obj
		) {
			Node node = obj as Node;
			if( node == null ) {
				return false;
			}
			
			return (
				this.Equals(
					node
				)
			);
		}

		public static bool operator ==(
			Node leftNode,
			Node rightNode
		) {
			return Object.Equals(
				leftNode,
				rightNode
			);
		}

		public static bool operator !=(
			Node leftNode,
			Node rightNode
		) {
			return !( leftNode == rightNode );
		}

		public override int GetHashCode() {
			int hash = 17;
			const int PRIME = 23;

			unchecked {
				hash = hash * PRIME + this.x.GetHashCode();
				hash = hash * PRIME + this.y.GetHashCode();
			}

			return hash;
		}

		public override string ToString() {
			return "( "
				+ x.ToString()
				+ ", "
				+ y.ToString()
				+ " )"
			;
		}
	}
}
