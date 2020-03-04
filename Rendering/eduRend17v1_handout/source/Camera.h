//
//  Camera.h
//
//	Basic camera class
//

#pragma once
#ifndef CAMERA_H
#define CAMERA_H

#include "vec\vec.h"
#include "vec\mat.h"
#include "math.h"
#include <cmath>
#include <iostream>

using namespace std;
using namespace linalg;

class camera_t
{
public:

	float vfov, aspect;	// Aperture attributes
	float zNear, zFar;	// Clip planes
						// zNear should be >0
						// zFar should depend on the size of the scene
	float mTheta;
	vec3f position, rot;
	mat4f ViewToWorld;

	camera_t(
		float vfov,
		float aspect,
		float zNear,
		float zFar):
		vfov(vfov), aspect(aspect), zNear(zNear), zFar(zFar)
	{

	}
	

	// Move to an absolute position
	//
	void moveTo(const vec3f& p)
	{
		position = p; //position = p + (ViewToWorld * (0,0,-1,0)) * velocity * dt;
	}

	// Move relatively
	//
	void move(const vec3f& v) //v = velocity * dt
	{
		mat4f vtw = ViewToWorld * (0, 0, -1, 0);
		/*position += v;*/

		position = position + vtw[3] * v;

		//v = ViewToWorld * (0,0,-1,0);
		//position = position + v * velocity * dt
		//v i detta fall = kolumnt  av matrisen ViewToWorld
	}
	void rotate(float grader, vec3f u) {
		mTheta += grader;
		rot = u;
		mTheta / 2;

		if (mTheta >= 360) {
			mTheta = 0;
		}
		//position += v.y;
	}

	// Return World-to-View matrix for this camera
	//
	mat4f get_WorldToViewMatrix()
	{
		// Assuming a camera's position and rotation is defined by matrices T(p) and R,
		// the View-to-World transform is T(p)*R (for a first-person style camera)
		// World-to-View then is the inverse of T*R;
		//	inverse(T(p)*R) = inverse(R)*inverse(T(p)) = transpose(R)*T(-p)
		// Since now there is no rotation, this matrix is simply T(-p)

		//return (mat4f::translation(-position)); 2 * 3.1415926535897f
		mat4f R = mat4f::rotation(mTheta, rot);
		ViewToWorld = mat4f::translation(position) * R; //ViewToWorld = TR
		return (transpose(R) * mat4f::translation(-position));
	}

	// Matrix transforming from View space to Clip space
	// In a performance sensitive situation this matrix can be precomputed, as long as
	// all parameters are constant (which typically is the case)
	//
	mat4f get_ProjectionMatrix()
	{
		return mat4f::projection(vfov, aspect, zNear, zFar);
	}
};

#endif